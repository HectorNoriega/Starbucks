namespace Starbucks.Application.Orders.Queries.GetOrderById
{
    public sealed record OrderDTO(Guid id, string clientName, string nameAttention,string status, DateTime dateCreated, List<OrderDetailDTO> orderDetails);
    public sealed record OrderDetailDTO(string productName, int quantity);
}
