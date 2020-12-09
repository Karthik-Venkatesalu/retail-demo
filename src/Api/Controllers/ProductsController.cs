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
    public class ProductsController : ControllerBase
    {
        private readonly IFacade _facade;

        public ProductsController(IFacade facade)
        {
            _facade = facade;
        }

        [HttpPost]
        public ActionResult Post(Request<Product> request)
        {
            try
            {
                return Ok(_facade.AddProduct(request));
            }
            catch
            {
                var errorResponse = Builder.InternalServerErrorResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }
    }
}
