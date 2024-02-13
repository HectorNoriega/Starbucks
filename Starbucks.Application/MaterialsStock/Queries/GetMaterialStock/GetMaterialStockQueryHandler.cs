using Starbucks.Application.Abstractions;
using Starbucks.Domain.Abstractions;
using Starbucks.Domain.Repositories;

namespace Starbucks.Application.MaterialsStock.Queries.GetMaterialStock
{
    internal sealed class GetMaterialStockQueryHandler : IQueryHandler<GetMaterialStockQuery, List<MaterialStockDTO>>
    {
        private readonly IMaterialStockRepository _materialStockRepository;
        private readonly IMaterialsRepository _materialRepository;

        public GetMaterialStockQueryHandler(IMaterialStockRepository materialStockRepository, IMaterialsRepository materialRepository)
        {
            _materialStockRepository = materialStockRepository;
            _materialRepository = materialRepository;
        }

        public async Task<List<MaterialStockDTO>> Handle(GetMaterialStockQuery request, CancellationToken cancellationToken)
        {
            var materials = await _materialRepository.GetMaterials(cancellationToken);
            var materialStock = await _materialStockRepository.GetMaterialsStock(cancellationToken);

            var listMaterialStockDTO = from m in materials
                                       join mstock in materialStock on m.Id equals mstock.IdMaterial
                                       select new MaterialStockDTO(
                                           m.Id,
                                           m.Name,
                                           m.Description,
                                           m.UnitOfMeasurement,
                                           mstock.StockQuantity
                                           );

            return listMaterialStockDTO.ToList();
        }
    }
}
