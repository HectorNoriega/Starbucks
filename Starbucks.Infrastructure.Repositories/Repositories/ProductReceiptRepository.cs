using Microsoft.EntityFrameworkCore;
using Starbucks.Domain.Abstractions;
using Starbucks.Domain.Entities;

namespace Starbucks.Infrastructure.Repositories
{
    public class ProductReceiptRepository: IProductReceiptRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductReceiptRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void InitProductsInMemoryDb()
        {
            var productReceipt = new List<ProductReceipt>
                {
                new(
                    Guid.Parse("e288c80f-839a-469e-a8b2-15c1432f0550"),
                    Guid.Parse("be889cc3-bf57-41d0-8ca8-d75746b3e39d"), //Frapucchino Mocca
                    Guid.Parse("c2b44be6-0158-47c4-9549-cef4cdc01f5e"), //Leche
                    300),
                new(
                    Guid.Parse("6a8b58fc-31d0-49d1-869f-f20d01c968da"),
                    Guid.Parse("be889cc3-bf57-41d0-8ca8-d75746b3e39d"), //Frapucchino Mocca
                    Guid.Parse("e271c8a3-1c7d-4f0b-9f24-d589d96be9de"), //Cafe
                    200),
                new(
                    Guid.Parse("65aa2ae7-a5d8-4df0-83a5-19e12d6bf2ac"),
                    Guid.Parse("be889cc3-bf57-41d0-8ca8-d75746b3e39d"), //Frapucchino Mocca
                    Guid.Parse("7961ad2a-af88-41cc-b7ed-6de8b805699c"), //Azucar
                    300),
                new(
                    Guid.Parse("52e21e5b-c248-4cba-9aef-d29677a8c004"),
                    Guid.Parse("be889cc3-bf57-41d0-8ca8-d75746b3e39d"), //Frapucchino Mocca
                    Guid.Parse("78f2f17b-1df0-472b-818f-dea8a7696dc2"), //Chocolate
                    100),
                new(
                    Guid.Parse("6a260818-886e-4710-8608-4aac67b4eb10"),
                    Guid.Parse("1ebe43fa-bbc9-4063-bf92-3976952f2bfd"), //Black tea
                    Guid.Parse("7961ad2a-af88-41cc-b7ed-6de8b805699c"), //Azucar
                    100),
                new(
                    Guid.Parse("f63957c3-fc40-4dfb-967e-6e2b777c9d20"),
                    Guid.Parse("1ebe43fa-bbc9-4063-bf92-3976952f2bfd"), //Black tea
                    Guid.Parse("0275ed5b-2e7e-42fd-9729-e612311466e4"), //Te
                    100),
                };

            _dbContext.ProductReceiptItem.AddRange(productReceipt);
            _dbContext.SaveChanges();
        }

        public async Task<List<ProductReceipt>> GetReceiptByProductId(Guid IdProduct, CancellationToken cancellationToken)
        {
            return await _dbContext.ProductReceiptItem.Where(x => x.IdProduct == IdProduct).ToListAsync(cancellationToken);
        }
    }
}
