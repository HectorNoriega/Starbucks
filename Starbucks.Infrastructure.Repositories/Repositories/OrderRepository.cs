using Microsoft.EntityFrameworkCore;
using Starbucks.Domain.Abstractions;
using Starbucks.Domain.Entities;

namespace Starbucks.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

        public async Task AddOrder(Order orderItem, CancellationToken cancellationToken)
        {
            _dbContext.OrderItems.Add(orderItem);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<Order> GetOrderById(Guid idOrder, CancellationToken cancellationToken)
        {
            var order = await _dbContext.OrderItems
                    .FindAsync(new object[] { idOrder }, cancellationToken);

            if (order == null)
            {
                return null;
            }

            return order;
        }

        public async Task<List<Order>> GetOrders(CancellationToken cancellationToken)
        {
            return await _dbContext.OrderItems.ToListAsync(cancellationToken);
        }

        public async Task<bool> UpdateOrder(Order order, CancellationToken cancellationToken) {
            var orderItem = await _dbContext
                .OrderItems
                .FirstOrDefaultAsync(x  => x.Id == order.Id, cancellationToken);

            if (orderItem == null)
            {
                return false;
            }

            orderItem.ClientName = order.ClientName;
            orderItem.NameAttention = order.NameAttention;
            orderItem.OrderStatus = order.OrderStatus;

            return false;
        }
    }
}
