using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Application.Product.Interfaces
{
    public interface IRepository
    {
        Domain.Entities.Product AddProduct(Domain.Entities.Product product);
        Domain.Entities.Product GetProduct(int productID);
        Domain.Entities.Product UpdateProduct(Domain.Entities.Product product);
        bool DeletProduct(int productID);
        List<Domain.Entities.Product> GetProducts(int[] productIDs);
        void BulkUpdateProductQuantity(List<Application.Dto.Model.OrderProduct> orderProducts);
    }
}
