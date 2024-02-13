using Microsoft.EntityFrameworkCore;
using Starbucks.Domain.Entities;
using Starbucks.Domain.Repositories;
using System.Threading;

namespace Starbucks.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;          
        }

        public void InitProductsInMemoryDb() {
            var products = new List<Product>
                {
                new Product
                (
                    Guid.Parse("be889cc3-bf57-41d0-8ca8-d75746b3e39d"),
                    "Frapucchino Mocca",
                    "Frapucchino Mocca",
                    12.50,
                    true
                    ),
                new Product
                (
                     Guid.Parse("1ebe43fa-bbc9-4063-bf92-3976952f2bfd"),
                    "Black Tea",
                    "Black Tea",
                    9.50,
                    true
                )
                };

            _dbContext.ProductItems.AddRange(products);
            _dbContext.SaveChanges();
        }

        public async Task AddProduct(Product productItem, CancellationToken cancellationToken)
        {
            _dbContext.ProductItems.Add(productItem);
            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        public async Task<List<Product>> GetProducts(CancellationToken cancellationToken)
        {
            return await _dbContext.ProductItems.ToListAsync(cancellationToken);
        }
    }
}
