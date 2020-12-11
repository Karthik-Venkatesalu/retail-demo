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
                var response = _facade.AddProduct(request);
                return CreatedAtAction(nameof(GetProduct), new { productID = response.Data.ID }, response);
            }
            catch
            {
                var errorResponse = Builder.InternalServerErrorResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpGet("{productID}")]
        public ActionResult GetProduct(int productID)
        {
            try
            {
                return Ok(_facade.GetProduct(productID));
            }
            catch
            {
                var errorResponse = Builder.InternalServerErrorResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpPut("{productID}")]
        public ActionResult UpdateProduct(int productID, [FromBody] Request<Product> product)
        {
            try
            {
                // TODO: validate if passed in productID is same as in request body
                return Ok(_facade.UpdateProduct(product));
            }
            catch
            {
                var errorResponse = Builder.InternalServerErrorResponse();
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }
        }

        [HttpDelete("{productID}")]
        public ActionResult DeleteProduct(int productID)
        {
            try
            {
                var errorResponse = _facade.DeleteProduct(productID);

                if (errorResponse != null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
                }

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
