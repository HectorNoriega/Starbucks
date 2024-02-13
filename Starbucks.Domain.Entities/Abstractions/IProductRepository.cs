using Starbucks.Domain.Entities;

namespace Starbucks.Domain.Repositories
{
    public interface IProductRepository
    {
        public Task AddProduct(Product productItem, CancellationToken cancellationToken);
        public Task<List<Product>> GetProducts(CancellationToken cancellationToken);
        public void InitProductsInMemoryDb();
    }
}
