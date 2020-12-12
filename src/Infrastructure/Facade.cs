using Application.Dto.Request;
using Application.Dto.Model;
using Application.Dto.Response.Model;
using Infrastructure.Interfaces;
using System.Collections.Generic;

namespace Infrastructure
{
    public class Facade : IFacade
    {
        private readonly Application.Product.Interfaces.IRepository _productRepository;
        private readonly Application.Order.Interfaces.IRepository _orderRepository;

        private readonly Application.Product.Interfaces.IRequestHandler _productRequestHandler;
        private readonly Application.Order.Interfaces.IRequestHandler _orderRequestHandler;

        public Facade(
            Application.Product.Interfaces.IRepository productRepository,
            Application.Order.Interfaces.IRepository orderRepository,
            Application.Product.Interfaces.IRequestHandler productRequestHandler,
            Application.Order.Interfaces.IRequestHandler orderRequestHandler)
        {
            _productRepository = productRepository;
            _productRequestHandler = productRequestHandler;

            _orderRepository = orderRepository;
            _orderRequestHandler = orderRequestHandler;
        }

        public Response<Product> AddProduct(Request<Product> productRequest)
        {
            return _productRequestHandler.AddProduct(productRequest);
        }

        public Response<Product> GetProduct(int productID)
        {
            return _productRequestHandler.GetProduct(productID);
        }

        public BaseResponse AddOrder(Request<Order> orderRequest)
        {
            return _orderRequestHandler.CreateOrder(orderRequest);
        }

        public void CancelOrder(int orderID)
        {
            _orderRequestHandler.CancelOrder(orderID);
        }

        public Response<Product> UpdateProduct(Request<Product> productRequest)
        {
            return _productRequestHandler.UpdateProduct(productRequest);
        }

        public BaseResponse DeleteProduct(int productID)
        {
            return _productRequestHandler.DeleteProduct(productID);
        }
    }
}
