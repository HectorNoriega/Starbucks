namespace Starbucks.Application.Orders.Commands
{
    public sealed record CreateOrderRequest(string ClientName, string NameAtention, List<CreateOrderDetailRequest> Details);
    public sealed record CreateOrderDetailRequest(Guid IdProduct, int Quantity);
}
