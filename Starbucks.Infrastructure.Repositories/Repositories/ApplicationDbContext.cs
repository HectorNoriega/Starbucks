using Microsoft.EntityFrameworkCore;
using Starbucks.Domain.Abstractions;
using Starbucks.Domain.Entities;

namespace Starbucks.Infrastructure
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Client> ClientItems { get; set; }
        public DbSet<Material> MaterialItems { get; set; }
        public DbSet<Order> OrderItems { get; set; }
        public DbSet<OrderDetail> OrderDetailItems { get; set; }
        public DbSet<Product> ProductItems { get; set; }
        public DbSet<MaterialStock> MaterialStockItem { get; set; }
        public DbSet<ProductReceipt> ProductReceiptItem { get; set; }
        //public DbSet<Tax> TaxItems { get; set; }
        //public DbSet<Bills> BillsItems { get; set; }
        //public DbSet<BillsDetails> BillsDetailsItems { get; set; }
    }
}
