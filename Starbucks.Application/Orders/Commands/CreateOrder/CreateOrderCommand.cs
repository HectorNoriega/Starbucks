using Starbucks.Application.Abstractions;

namespace Starbucks.Application.Orders.Commands
{
    public sealed record CreateOrderCommand(string ClientName, string NameAtention, List<CreateOrderDetailRequest> Details): ICommand<Guid>;
}
