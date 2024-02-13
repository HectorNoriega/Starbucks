using Starbucks.Application.Abstractions;
using Starbucks.Application.Orders.Queries.GetOrderById;

namespace Starbucks.Application.Orders.Queries.GetOrders
{
    public sealed record GetOrdersQuery() : IQuery<List<OrderDTO>>;
}
