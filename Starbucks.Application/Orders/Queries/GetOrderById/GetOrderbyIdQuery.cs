using Starbucks.Application.Abstractions;

namespace Starbucks.Application.Orders.Queries.GetOrderById
{
    public sealed record GetOrderByIdQuery(Guid orderId) : IQuery<OrderDTO>;
}
