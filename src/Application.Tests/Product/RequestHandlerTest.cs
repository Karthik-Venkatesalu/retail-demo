using Application.Dto.Response.Model;
using Application.Product;
using Application.Product.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Application.Tests.Product
{
    public class RequestHandlerTest
    {
        [Fact]
        public void GetProduct_WithValidProductID_ReturnsProductObject()
        {
            Mock<IRepository> productRepository = new Mock<IRepository>();

            productRepository
                .Setup(rep => rep.GetProduct(It.IsAny<int>()))
                .Returns(new Domain.Entities.Product()
                {
                    ID = 1,
                    Description = "test",
                    Name = "Dell",
                    Price = 350,
                    Quantity = 1
                });

            RequestHandler requestHandler = new RequestHandler(productRepository.Object);
            var response = requestHandler.GetProduct(1);

            Assert.NotNull(response);
            Assert.IsType<Response<Dto.Model.Product>>(response);
        }

        [Fact]
        public void DeleteProduct_WithInValidProductID_ReturnsErrorResponse()
        {
            Mock<IRepository> productRepository = new Mock<IRepository>();

            productRepository
                .Setup(rep => rep.DeletProduct(It.IsAny<int>()))
                .Returns(false);

            RequestHandler requestHandler = new RequestHandler(productRepository.Object);
            var response = requestHandler.DeleteProduct(1);

            Assert.NotNull(response);
            Assert.IsType<ErrorResponse>(response);

            var errorResponse = response as ErrorResponse;
            Assert.Single(errorResponse.Errors.ErrorList);

            var errorObject = errorResponse.Errors.ErrorList.First();
            Assert.Equal("425", errorObject.Code);
            Assert.Equal("Failed to delete product, id - 1", errorObject.Detail);
            Assert.Equal("500", errorObject.Status);
            Assert.Equal("Internal server error", errorObject.Title);
        }
    }
}
