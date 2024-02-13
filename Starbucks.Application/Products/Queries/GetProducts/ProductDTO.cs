namespace Starbucks.Application.Products.Queries.GetProducts
{
    public sealed record ProductDTO(Guid id, string Name, string description, double price, bool status);
}
