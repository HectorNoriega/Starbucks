using MediatR;
using Microsoft.AspNetCore.Mvc;
using Starbucks.Application.MaterialsStock.Commands.SetStockMaterials;
using Starbucks.Application.MaterialsStock.Queries.GetMaterialStock;
using Starbucks.Application.Orders.Commands.PaidOrder;
using Starbucks.Application.Products.Queries.GetProducts;

namespace Starbucks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialStockController : ControllerBase
    {
        private ISender _sender;
        protected ISender Sender => _sender ??= HttpContext.RequestServices.GetService<ISender>();

        [HttpGet]
        [ProducesResponseType(typeof(ProductDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetStockMaterials(CancellationToken cancellationToken)
        {
            var query = new GetMaterialStockQuery();

            var products = await Sender.Send(query, cancellationToken);

            if (products.Count == 0) return NoContent();

            return Ok(products);
        }

        [HttpPost]
        [ProducesResponseType(typeof(bool), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> UpdateOrderStatusPaid(
             [FromBody] SetStockMaterialsCommand request,
             CancellationToken cancellationToken)
        {
            var updateSuccesfull = await Sender.Send(request, cancellationToken);

            if (!updateSuccesfull) return NotFound();

            return Ok();
        }
    }
}
