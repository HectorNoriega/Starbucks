namespace Starbucks.Domain.Entities
{
    public class Material: Entity
    {
        public Material(Guid id, string name, string description, string unitOfMeasurement):base(id)
        {
            Id = id;
            Name = name;
            Description = description;
            UnitOfMeasurement = unitOfMeasurement;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UnitOfMeasurement { get; set; }
    }
}
