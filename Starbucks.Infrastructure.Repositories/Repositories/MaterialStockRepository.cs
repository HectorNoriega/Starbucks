using Microsoft.EntityFrameworkCore;
using Starbucks.Domain.Abstractions;
using Starbucks.Domain.Entities;

namespace Starbucks.Infrastructure.Repositories
{
    public class MaterialStockRepository: IMaterialStockRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public MaterialStockRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<MaterialStock>> GetMaterialsStock(CancellationToken cancellationToken)
        {
            return await _dbContext.MaterialStockItem.ToListAsync(cancellationToken);
        }

        public async Task<bool> UpdateMaterialStock(List<MaterialStock> materialStocksUpdate, CancellationToken cancellationToken)
        {
            var materialStockItems = await _dbContext
               .MaterialStockItem.ToListAsync(cancellationToken);

            if (materialStockItems.Count == 0)
            {
                return false;
            }

            foreach (var materialStockUpdate in materialStocksUpdate)
            { 
                var materialStockItem = materialStockItems.Where(x => x.Id == materialStockUpdate.Id).FirstOrDefault();

                if(materialStockItem != null)
                {
                    materialStockItem.StockQuantity = materialStockUpdate.StockQuantity;
                }
            }

            return true;
        }

        public void InitProductsInMemoryDb()
        {
            var materialStocks = new List<MaterialStock>
                {
                new
                (
                    Guid.Parse("3e30c967-b220-43b9-a041-526e1f6ec753"),
                    Guid.Parse("c2b44be6-0158-47c4-9549-cef4cdc01f5e"), //Leche deslactosada
                    150
                    ),
                new
                (
                     Guid.Parse("26523f6c-c5d3-4e7c-afc5-24775f17cc0f"),
                   Guid.Parse("e271c8a3-1c7d-4f0b-9f24-d589d96be9de"), // Cafe
                    150
                ),
                  new
                (
                     Guid.Parse("a83aa885-d301-4209-a99c-58f1d8863d17"),
                   Guid.Parse("78f2f17b-1df0-472b-818f-dea8a7696dc2"), //Chocolate
                    100
                ),
                    new
                (
                     Guid.Parse("da330d3c-652f-4ed8-99cb-f8535aa7263f"),
                   Guid.Parse("7961ad2a-af88-41cc-b7ed-6de8b805699c"), //Azucar
                    300
                ),
                     new (
                     Guid.Parse("9f12ee6a-e565-477e-8198-cf1daf06c56d"),
                   Guid.Parse("0275ed5b-2e7e-42fd-9729-e612311466e4"), //Te
                    300
                ),
                };

            _dbContext.MaterialStockItem.AddRange(materialStocks);
            _dbContext.SaveChanges();
        }

    }
}
