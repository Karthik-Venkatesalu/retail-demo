using Application.Order.Interfaces;
using Application.Response;
using Application.Dto.Response.Model;
using System;
using Application.Dto.Request;
using System.Linq;
using System.Collections.Generic;

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
            var validateResponse = ValidateOrder(orderRequest.Data);

            if (validateResponse != null)
            {
                return validateResponse;
            }

            return Builder.BuildSuccessResponse(_repository.CreateOrder(orderRequest.Data.MapToDomain(), orderRequest.Data.Items).MapToDto(orderRequest.Data.Items));
        }

        public void CancelOrder(int orderID)
        {
            _repository.CancelOrder(orderID);
        }

        public BaseResponse ValidateOrder(Application.Dto.Model.Order orderDto)
        {
            var dbProducts = _productRepository.GetProducts(orderDto.Items.Select(i => i.ID).ToArray());
            var invalidIDs = orderDto.Items.Where(item => dbProducts.Any(p => p.ID.Value == item.ID) == false).ToList();

            if (invalidIDs.Count > 0)
            {
                return Response.Builder.BuildErrorResponse(new Errors()
                {
                    ErrorList = new List<Error> { new Error() {
                        Code = "435",
                        Detail = $"invalid product ids - {string.Join(", ", invalidIDs)}",
                        Id = Guid.NewGuid().ToString(),
                        Status = "400",
                        Title = "Invalid request"
                    } }
                });
            }

            var insufficientQuantities = new List<Dto.Model.OrderProduct>();
            orderDto.Items.ForEach(item =>
            {
                var orderedItem = dbProducts.First(p => p.ID == item.ID);
                if (item.Quantity > orderedItem.Quantity)
                {
                    insufficientQuantities.Add(item);
                }
            });

            if (insufficientQuantities.Count > 0)
            {
                return Response.Builder.BuildErrorResponse(new Errors()
                {
                    ErrorList = new List<Error> { new Error() {
                        Code = "435",
                        Detail = $"Insufficient quantity for products - {string.Join(", ", insufficientQuantities.Select(i => i.ID))}",
                        Id = Guid.NewGuid().ToString(),
                        Status = "400",
                        Title = "Invalid request"
                    } }
                });
            }

            return null;
        }

    }
}
