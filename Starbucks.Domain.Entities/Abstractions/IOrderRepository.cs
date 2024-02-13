using Starbucks.Domain.Entities;

namespace Starbucks.Domain.Abstractions
{
    public interface IOrderRepository
    {
        public Task AddOrder(Order orderItem, CancellationToken cancellationToken);
        public Task<Order> GetOrderById(Guid idOrder, CancellationToken cancellationToken);
        public Task<List<Order>> GetOrders(CancellationToken cancellationToken);
        public Task<bool> UpdateOrder(Order order, CancellationToken cancellationToken);
    }
}
