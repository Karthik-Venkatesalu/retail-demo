using Application.Dto.Response.Model;
using Application.Dto.Request;
using System.Collections.Generic;

namespace Application.Product.Interfaces
{
    public interface IRequestHandler
    {
        Response<Dto.Model.Product> AddProduct(Request<Dto.Model.Product> productRequest);
        Response<Dto.Model.Product> GetProduct(int productID);
        Response<Dto.Model.Product> UpdateProduct(Request<Dto.Model.Product> productRequest);
        BaseResponse DeleteProduct(int productID);
    }
}