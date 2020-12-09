using Application.Order.Interfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class OrderRepository : IRepository
    {
        public OrderRepository()
        {
        }

        public Order GetOrder(int orderID)
        {
            return new Order();
        }

        public Order CreateOrder(Order order)
        {
            // TODO: Logic to persist in the data store must go here.
            var newOrder = new Order();
            return newOrder;
        }
    }
}
