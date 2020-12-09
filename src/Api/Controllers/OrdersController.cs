using Application.Dto.Request;
using Application.Response;
using Application.Dto.Model;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IFacade _facade;

        public OrdersController(IFacade facade)
        {
            _facade = facade;
        }

        [HttpPost]
        public ActionResult Post(Request<Order> request)
        {
            try
            {
                return StatusCode(StatusCodes.Status201Created, _facade.AddOrder(request));
            }
            catch
            {
                var errorResponse = Builder.InternalServerErrorResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpGet("{orderID}")]
        public ActionResult GetOrder(int orderID)
        {
            try
            {
                return Ok(_facade.GetOrder(orderID));
            }
            catch
            {
                var errorResponse = Builder.InternalServerErrorResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}
