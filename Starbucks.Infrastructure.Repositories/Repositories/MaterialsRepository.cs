using Microsoft.EntityFrameworkCore;
using Starbucks.Domain.Entities;
using Starbucks.Domain.Repositories;

namespace Starbucks.Infrastructure.Repositories
{
    public class MaterialsRepository : IMaterialsRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public MaterialsRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InitProductsInMemoryDb()
        {
            var materials = new List<Material>
                {
                new (
                    Guid.Parse("c2b44be6-0158-47c4-9549-cef4cdc01f5e"),
                    "Leche",
                    "Leche deslactosada",
                    "l"
                    ),
                new (
                    Guid.Parse("e271c8a3-1c7d-4f0b-9f24-d589d96be9de"),
                    "Cafe",
                    "Cafe",
                    "l"
                    ),
                 new (
                    Guid.Parse("78f2f17b-1df0-472b-818f-dea8a7696dc2"),
                    "Chocolate",
                    "Chocolate",
                    "g"
                    ),
                  new (
                    Guid.Parse("7961ad2a-af88-41cc-b7ed-6de8b805699c"),
                    "Azucar",
                    "Azucar",
                    "g"
                    ),
                  new (
                    Guid.Parse("0275ed5b-2e7e-42fd-9729-e612311466e4"),
                    "Te",
                    "Te",
                    "g"
                    ),
                };

            _dbContext.MaterialItems.AddRange(materials);
            _dbContext.SaveChanges();
        }

        public async Task<List<Material>> GetMaterials(CancellationToken cancellationToken)
        {
            return await _dbContext.MaterialItems.ToListAsync(cancellationToken);
        }
    }
}
