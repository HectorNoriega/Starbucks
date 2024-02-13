using Starbucks.Application.Abstractions;

namespace Starbucks.Application.MaterialsStock.Commands.SetStockMaterials
{
    public sealed record SetStockMaterialsCommand(Guid IdOrder) : ICommand<bool>;
}
