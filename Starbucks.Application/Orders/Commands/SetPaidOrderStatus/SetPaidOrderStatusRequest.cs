using Starbucks.Application.Abstractions;

namespace Starbucks.Application.Orders.Commands.PaidOrder
{
    public sealed record SetPaidOrderStatusRequest(Guid IdOrder);
}
