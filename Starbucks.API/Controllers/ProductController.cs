using MediatR;
using Microsoft.AspNetCore.Mvc;
using Starbucks.Application.Products.Queries.GetProducts;

namespace Starbucks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private ISender _sender;

        public ProductController(ISender sender)
        {
            _sender = sender;
        }

        [HttpGet]
        [ProducesResponseType(typeof(ProductDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetProducts(CancellationToken cancellationToken)
        {
            var query = new GetProductsQuery();

            var products = await _sender.Send(query, cancellationToken);

            if (products.Count == 0) return NoContent();

            return Ok(products);
        }
    }
}
