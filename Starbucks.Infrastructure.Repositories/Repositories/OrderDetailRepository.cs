using Microsoft.EntityFrameworkCore;
using Starbucks.Domain.Abstractions;
using Starbucks.Domain.Entities;

namespace Starbucks.Infrastructure.Repositories
{
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public OrderDetailRepository(ApplicationDbContext dbContext) => _dbContext = dbContext;

        public async Task AddOrdersDetails(List<OrderDetail> listOrderDetailItem, CancellationToken cancellationToken)
        {
            _dbContext.OrderDetailItems.AddRange(listOrderDetailItem);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<OrderDetail>> GetOrdersByOrderId(Guid idOrder, CancellationToken cancellationToken)
        {
            var orderDetails = await _dbContext.OrderDetailItems.Where(x => x.IdOrder == idOrder).ToListAsync(cancellationToken);

            if (orderDetails.Count == 0)
            {
                return null;
            }

            return orderDetails;
        }
    }
}
