using Starbucks.Domain.Entities;

namespace Starbucks.Domain.Abstractions
{
    public interface IProductReceiptRepository
    {
        public Task<List<ProductReceipt>> GetReceiptByProductId(Guid IdProduct, CancellationToken cancellationToken);
        public void InitProductsInMemoryDb();
    }
}
