using Starbucks.Domain.Entities;

namespace Starbucks.Domain.Repositories
{
    public interface IMaterialsRepository
    {
        public Task<List<Material>> GetMaterials(CancellationToken cancellationToken);
        void InitProductsInMemoryDb();
    }
}
