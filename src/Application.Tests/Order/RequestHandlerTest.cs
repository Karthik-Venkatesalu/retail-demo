using Application.Dto.Response.Model;
using Application.Order;
using Application.Order.Interfaces;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Application.Tests.Order
{
    public class RequestHandlerTest
    {
        [Fact]
        public void ValidateOrder_WithInvalidProductIDs_ReturnErrorResponse()
        {
            Mock<IRepository> orderRepository = new Mock<IRepository>();
            Mock<Application.Product.Interfaces.IRepository> productRepository = new Mock<Application.Product.Interfaces.IRepository>();

            productRepository
                .Setup(rep => rep.GetProducts(It.IsAny<int[]>()))
                .Returns(new List<Domain.Entities.Product>()
                    {
                        new Domain.Entities.Product() {
                            ID = 1,
                            Description = "test",
                            Name = "Dell",
                            Price = 350,
                            Quantity = 1
                        }
                    });

            RequestHandler requestHandler = new RequestHandler(orderRepository.Object, productRepository.Object);
            var response = requestHandler.ValidateOrder(new Dto.Model.Order()
            {
                AddressID = 1,
                Items = new List<Dto.Model.OrderProduct>()
                {
                    new Dto.Model.OrderProduct()
                    {
                        ID = 2,
                        Quantity = 100
                    }
                }
            });

            Assert.NotNull(response);
            Assert.IsType<ErrorResponse>(response);

            var errorResponse = response as ErrorResponse;
            Assert.Single(errorResponse.Errors.ErrorList);

            var errorObject = errorResponse.Errors.ErrorList.First();
            Assert.Equal("435", errorObject.Code);
            Assert.Equal("Invalid product ids - 2", errorObject.Detail);
            Assert.Equal("400", errorObject.Status);
            Assert.Equal("Invalid request", errorObject.Title);
        }

        [Fact]
        public void ValidateOrder_WithInvalidQuantity_ReturnErrorResponse()
        {
            Mock<IRepository> orderRepository = new Mock<IRepository>();
            Mock<Application.Product.Interfaces.IRepository> productRepository = new Mock<Application.Product.Interfaces.IRepository>();

            productRepository
                .Setup(rep => rep.GetProducts(It.IsAny<int[]>()))
                .Returns(new List<Domain.Entities.Product>()
                    {
                        new Domain.Entities.Product() {
                            ID = 1,
                            Description = "test",
                            Name = "Dell",
                            Price = 350,
                            Quantity = 1
                        }
                    });

            RequestHandler requestHandler = new RequestHandler(orderRepository.Object, productRepository.Object);
            var response = requestHandler.ValidateOrder(new Dto.Model.Order()
            {
                AddressID = 1,
                Items = new List<Dto.Model.OrderProduct>()
                {
                    new Dto.Model.OrderProduct()
                    {
                        ID = 1,
                        Quantity = 100
                    }
                }
            });

            Assert.NotNull(response);
            Assert.IsType<ErrorResponse>(response);

            var errorResponse = response as ErrorResponse;
            Assert.Single(errorResponse.Errors.ErrorList);

            var errorObject = errorResponse.Errors.ErrorList.First();
            Assert.Equal("415", errorObject.Code);
            Assert.Equal("Insufficient quantity for products - 1", errorObject.Detail);
            Assert.Equal("400", errorObject.Status);
            Assert.Equal("Invalid request", errorObject.Title);
        }

        [Fact]
        public void ValidateOrder_WithValidInput_ReturnNull()
        {
            Mock<IRepository> orderRepository = new Mock<IRepository>();
            Mock<Application.Product.Interfaces.IRepository> productRepository = new Mock<Application.Product.Interfaces.IRepository>();

            productRepository
                .Setup(rep => rep.GetProducts(It.IsAny<int[]>()))
                .Returns(new List<Domain.Entities.Product>()
                    {
                        new Domain.Entities.Product() {
                            ID = 1,
                            Description = "test",
                            Name = "Dell",
                            Price = 350,
                            Quantity = 200
                        }
                    });

            RequestHandler requestHandler = new RequestHandler(orderRepository.Object, productRepository.Object);
            var response = requestHandler.ValidateOrder(new Dto.Model.Order()
            {
                AddressID = 1,
                Items = new List<Dto.Model.OrderProduct>()
                {
                    new Dto.Model.OrderProduct()
                    {
                        ID = 1,
                        Quantity = 100
                    }
                }
            });

            Assert.Null(response);
        }
    }
}
