using Application.Product.Interfaces;
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
    public class ProductRepository : IRepository
    {
        private readonly string _connectionString;

        public ProductRepository()
        {
            _connectionString = Configuration.GetDBConnectionString();
        }

        public Product AddProduct(Product product)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                var parameters = new
                {
                    name = product.Name,
                    description = product.Description,
                    quantity = product.Quantity,
                    price = product.Price
                };
                product.ID = connection.ExecuteScalar<int>($"insert into retail.product (name, description, quantity, price) values (@name, @description, @quantity, @price) RETURNING id;", parameters);
            }

            return product;
        }

        public bool DeletProduct(int productID)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();
                return connection.Execute($"delete from retail.product where id = @productID", new { productID }) > 0;
            }
        }

        public Domain.Entities.Product GetProduct(int productID)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                var query = @"select 
                    id as ID, 
                    name as Name, 
                    description as Description, 
                    quantity as Quantity,
                    price as Price
                    from retail.product
                    where id = @productID";

                return connection.Query<Product>(query, new { productID }).SingleOrDefault();
            }
        }

        public List<Domain.Entities.Product> GetProducts(int[] productIDs)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                connection.Open();

                var query = @"select 
                    id as ID, 
                    name as Name, 
                    description as Description, 
                    quantity as Quantity,
                    price as Price
                    from retail.product
                    where id in (@productIDs)";

                return connection.Query<Product>(query, new { productIDs }).ToList();
            }
        }

        public Product UpdateProduct(Product product)
        {
            using (var connection = new NpgsqlConnection())
            {
                connection.Open();
                var parameters = new
                {
                    productID = product.ID,
                    name = product.Name,
                    description = product.Description,
                    quantity = product.Quantity,
                    price = product.Price
                };
                if (connection.Execute($"update retail.product set name = @name, description = @description, quantity = @quantity, price = @price where id = @productID;", parameters) > 0)
                {
                    return product;
                }
            }

            return null;
        }

        public void BulkUpdateProductQuantity(List<Application.Dto.Model.OrderProduct> orderProducts)
        {
            using (var connection = new NpgsqlConnection())
            {
                connection.Open();
                var parameters = orderProducts.Select(product => new
                {
                    productID = product.ID,
                    quantity = product.Quantity,
                });
                connection.Execute($"update retail.product set quantity = quantity - @quantity where id = @productID;", parameters);
            }
        }
    }
}
