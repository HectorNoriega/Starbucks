namespace Starbucks.Domain.Entities
{
    public class Product: Entity
    {
        public Product(Guid id, string name, string description, double price, bool status) : base(id)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            Status = status;
        }

        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool Status { get; set; }
    }
}
