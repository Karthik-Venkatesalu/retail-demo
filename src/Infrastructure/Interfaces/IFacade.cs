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

        // Order
        BaseResponse AddOrder(Request<Order> orderRequest);
        Response<Order> GetOrder(int orderID);
    }
}
