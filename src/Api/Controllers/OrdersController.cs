using Application.Dto.Request;
using Application.Response;
using Application.Dto.Model;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Application.Dto.Response.Model;

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
                var response = _facade.AddOrder(request);

                if (response is ErrorResponse)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, response);
                }
                
                return StatusCode(StatusCodes.Status201Created, response);
            }
            catch
            {
                var errorResponse = Builder.InternalServerErrorResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpDelete("{orderID}")]
        public ActionResult CancelOrder(int orderID)
        {
            try
            {
                _facade.CancelOrder(orderID);
                return NoContent();
            }
            catch
            {
                var errorResponse = Builder.InternalServerErrorResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}
