using Application.Product.Interfaces;
using Domain.Entities;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IRepository
    {
        public ProductRepository()
        {
        }

        public Product AddProduct(Product product)
        {
            var newProduct = new Product();
            return newProduct;
        }

        public Domain.Entities.Product GetProduct(int productID)
        {
            return new Product();
        }
    }
}
