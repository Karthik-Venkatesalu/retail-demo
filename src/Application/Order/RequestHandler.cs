using Application.Order.Interfaces;
using Application.Response;
using Application.Dto.Response.Model;
using System;
using Application.Dto.Request;

namespace Application.Order
{
    public class RequestHandler : IRequestHandler
    {
        private readonly IRepository _repository;
        private readonly Product.Interfaces.IRepository _productRepository;

        public RequestHandler(
            IRepository repository, 
            Product.Interfaces.IRepository propertyRepository)
        {
            _repository = repository ?? throw new ArgumentNullException("repository");
            _productRepository = propertyRepository ?? throw new ArgumentNullException("productRepository");
        }

        public BaseResponse CreateOrder(Request<Dto.Model.Order> orderRequest)
        {
            return Builder.BuildSuccessResponse(_repository.CreateOrder(orderRequest.Data.MapToDomain()).MapToDto());
        }

        public Response<Dto.Model.Order> GetOrder(int orderID)
        {
            return Builder.BuildSuccessResponse(_repository.GetOrder(orderID).MapToDto());
        }
    }
}
