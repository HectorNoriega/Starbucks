using Starbucks.Application.Abstractions;

namespace Starbucks.Application.MaterialsStock.Queries.GetMaterialStock
{
    public sealed record GetMaterialStockQuery() : IQuery<List<MaterialStockDTO>>;
}
