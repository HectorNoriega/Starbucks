using Starbucks.Domain.Entities;

namespace Starbucks.Domain.Abstractions
{
    public interface IOrderDetailRepository
    {
        public Task AddOrdersDetails(List<OrderDetail> listOrderDetailItem, CancellationToken cancellationToken);
        public Task<List<OrderDetail>> GetOrdersByOrderId(Guid idOrder, CancellationToken cancellationToken);
    }
}
