namespace Starbucks.Application.MaterialsStock.Queries.GetMaterialStock
{
    public sealed record MaterialStockDTO(Guid id, string name, string description, string unitOfMeasurement, double quantity);
}
