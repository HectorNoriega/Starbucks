using Starbucks.Domain.Entities;

namespace Starbucks.Domain.Abstractions
{
    public interface IMaterialStockRepository
    {
        public Task<List<MaterialStock>> GetMaterialsStock(CancellationToken cancellationToken);
        public Task<bool> UpdateMaterialStock(List<MaterialStock> materialStocksUpdate, CancellationToken cancellationToken);
        public void InitProductsInMemoryDb();
    }
}
