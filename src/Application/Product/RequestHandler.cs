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
    }
}
