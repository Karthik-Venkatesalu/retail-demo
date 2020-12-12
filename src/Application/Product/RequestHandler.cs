using Application.Product.Interfaces;
using Application.Dto.Request;
using Application.Dto.Response.Model;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Application.Product
{
    public class RequestHandler : IRequestHandler
    {
        private readonly IRepository _repository;

        public RequestHandler(IRepository repository)
        {
            _repository = repository ?? throw new ArgumentNullException("repository");
        }

        public Response<Dto.Model.Product> AddProduct(Request<Dto.Model.Product> propertyRequest)
        {
            var newProperty = _repository
                .AddProduct(propertyRequest.Data.MapToDomain())
                .MapToDto();

            return Response.Builder.BuildSuccessResponse(newProperty);
        }

        public Response<Dto.Model.Product> GetProduct(int productID)
        {
            var newProperty = _repository
                .GetProduct(productID)
                .MapToDto();

            return Response.Builder.BuildSuccessResponse(newProperty);
        }

        public Response<Dto.Model.Product> UpdateProduct(Request<Dto.Model.Product> propertyRequest)
        {
            var newProperty = _repository
                .UpdateProduct(propertyRequest.Data.MapToDomain())
                .MapToDto();

            return Response.Builder.BuildSuccessResponse(newProperty);
        }

        public BaseResponse DeleteProduct(int productID)
        {
            bool deleted = _repository
                .DeletProduct(productID);

            if (!deleted)
            {
                return Response.Builder.BuildErrorResponse(new Errors()
                {
                    ErrorList = new List<Error> { new Error() {
                        Code = "425",
                        Detail = $"Failed to delete product, id - {productID}",
                        Id = Guid.NewGuid().ToString(),
                        Status = "500",
                        Title = "Internal server error"
                    } }
                });
            }

            return null;
        }
    }
}
