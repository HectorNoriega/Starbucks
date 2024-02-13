namespace Starbucks.Domain.Entities
{
    public class MaterialStock: Entity
    {
        public MaterialStock(Guid id, Guid idMaterial, double stockQuantity) : base(id)
        {
            Id = id;
            IdMaterial = idMaterial;
            StockQuantity = stockQuantity;
        }

        public Guid IdMaterial { get; set; }
        public double StockQuantity { get; set; }
    }
}
