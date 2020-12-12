using Application.Dto.Request;
using Application.Dto.Response.Model;
using Application.Dto.Model;
using System.Collections.Generic;

namespace Infrastructure.Interfaces
{
    public interface IFacade
    {
        // Product
        Response<Product> AddProduct(Request<Product> productRequest);
        Response<Product> GetProduct(int productID);
        Response<Product> UpdateProduct(Request<Product> productRequest);
        BaseResponse DeleteProduct(int productID);

        // Order
        BaseResponse AddOrder(Request<Order> orderRequest);
        void CancelOrder(int orderID);
    }
}
