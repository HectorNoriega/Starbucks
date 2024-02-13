namespace Starbucks.Domain.Entities
{
    public sealed class ProductReceipt : Entity
    {
        public ProductReceipt(Guid id, Guid idProduct, Guid idMaterial, double quantity) : base(id)
        {
            Id = id;
            IdProduct = idProduct;
            IdMaterial = idMaterial;
            Quantity = quantity;
        }

        public Guid IdProduct { get; set; }
        public Guid IdMaterial { get; set; }
        public double Quantity { get; set; }
    }
}
