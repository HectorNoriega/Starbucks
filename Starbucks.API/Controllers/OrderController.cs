using Mapster;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Starbucks.Application.Orders.Commands;
using Starbucks.Application.Orders.Commands.PaidOrder;
using Starbucks.Application.Orders.Queries.GetOrderById;
using Starbucks.Application.Orders.Queries.GetOrders;

namespace Starbucks.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private ISender _sender;
        protected ISender Sender => _sender ??= HttpContext.RequestServices.GetService<ISender>();

        [HttpGet("{orderId:guid}")]
        [ProducesResponseType(typeof(OrderDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOrder(Guid orderId, CancellationToken cancellationToken)
        {
            var query = new GetOrderByIdQuery(orderId);

            var order = await Sender.Send(query, cancellationToken);

            if(order == null) return NotFound();

            return Ok(order);
        }


        [HttpGet]
        [ProducesResponseType(typeof(OrderDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetOrders(CancellationToken cancellationToken)
        {
            var query = new GetOrdersQuery();

            var order = await Sender.Send(query, cancellationToken);

            if (order == null) return NotFound();

            return Ok(order);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> CreateOrder(
       [FromBody] CreateOrderRequest request,
       CancellationToken cancellationToken)
        {
            var command = request.Adapt<CreateOrderCommand>();

            var orderId = await Sender.Send(command, cancellationToken);

            return CreatedAtAction(nameof(GetOrder), new { orderId }, orderId);
        }

        [Route("paid")]
        [HttpPut]
        [ProducesResponseType(typeof(Guid), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateOrderStatusPaid(
            [FromBody] SetPaidOrderStatusRequest request,
            CancellationToken cancellationToken)
        {
            var command = request.Adapt<SetPaidOrderStatusCommand>();

            var updateSuccesfull = await Sender.Send(command, cancellationToken);

            if(!updateSuccesfull) return NotFound();

            return Ok();
        }
    }
}
