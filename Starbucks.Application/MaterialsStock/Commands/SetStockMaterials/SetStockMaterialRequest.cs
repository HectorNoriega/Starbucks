namespace Starbucks.Application.MaterialsStock.Commands.SetStockMaterials
{
    public sealed record SetStockMaterialRequest(Guid idMaterial, double stockQuantity);
}
