using Application.Order;
using Application.Order.Interfaces;
using Dapper;
using Domain.Entities;
using Infrastructure.Service;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class OrderRepository : IRepository
    {
        private readonly string _connectionString;
        private readonly Application.Product.Interfaces.IRepository _productRepository;

        public OrderRepository(Application.Product.Interfaces.IRepository productRepository)
        {
            _connectionString = Configuration.GetDBConnectionString();
            _productRepository = productRepository;
        }

        public void CancelOrder(int orderID)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (NpgsqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        connection.Execute(
                            sql: $"update retail.order set status = 'cancelled' where id = @orderID;",
                            param: new { orderID },
                            transaction: transaction);

                        var orderProducts = connection.Query<Domain.Entities.OrderProduct>("select order_id as OrderID, product_id as ProductID, quantity as Quantity from retail.orderproduct where order_id = @orderID", new { orderID });
                        connection.Execute($"update retail.product set quantity = quantity + @Quantity where id = @ProductID;", orderProducts, transaction);

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public Order CreateOrder(Domain.Entities.Order order, List<Application.Dto.Model.OrderProduct> orderProducts)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                using (NpgsqlTransaction transaction = connection.BeginTransaction())
                {
                    try
                    {
                        var parameters = new
                        {
                            addressId = order.AddressID,
                            createdTime = DateTime.UtcNow,
                            status = order.Status
                        };

                        order.ID = connection.ExecuteScalar<int>(
                            sql: $"insert into retail.order (address_id, created_time, updated_time, status) values (@addressId, @createdTime, @updatedTime, @status) RETURNING id;",
                            param: parameters,
                            transaction: transaction);

                        var products = orderProducts.Select(op => new { OrderID = order.ID, ProductID = op.ID, Quantity = op.Quantity }).ToArray();
                        connection.Execute(
                            sql: $"insert into retail.orderproduct (order_id, product_id, quantity) values (@OrderID, @ProductID, @Quantity);",
                            param: products,
                            transaction: transaction);

                        _productRepository.BulkUpdateProductQuantity(orderProducts);

                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }

            return order;
        }

    }
}
