using Starbucks.Application.Abstractions;
using Starbucks.Domain.Abstractions;
using Starbucks.Domain.Entities;

namespace Starbucks.Application.MaterialsStock.Commands.SetStockMaterials
{
    internal sealed class SetStockMaterialCommandHandler : ICommandHandler<SetStockMaterialsCommand, bool>
    {
        private readonly IMaterialStockRepository _materialStockRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IProductReceiptRepository _productReceiptRepository;
        private readonly IUnitOfWork _unitOfWork;

        public SetStockMaterialCommandHandler(IMaterialStockRepository materialStockRepository
            , IUnitOfWork unitOfWork
            , IOrderDetailRepository orderDetailRepository
            , IProductReceiptRepository productReceiptRepository)
        {
            _materialStockRepository = materialStockRepository;
            _unitOfWork = unitOfWork;
            _orderDetailRepository = orderDetailRepository;
            _productReceiptRepository = productReceiptRepository;
        }

        public async Task<bool> Handle(SetStockMaterialsCommand request, CancellationToken cancellationToken)
        {
            var orderDetails = await _orderDetailRepository.GetOrdersByOrderId(request.IdOrder, cancellationToken);
            var materialsStock = await _materialStockRepository.GetMaterialsStock(cancellationToken);
            var materialStocksToUpdate = new List<MaterialStock>();

            foreach(var orderDetail in orderDetails)
            {
                var productReceipts = await _productReceiptRepository.GetReceiptByProductId(orderDetail.IdProduct, cancellationToken);

                foreach (var productReceipt in productReceipts) {
                    var materialStock = materialsStock.Where(x => x.IdMaterial == productReceipt.IdMaterial).FirstOrDefault();

                    if (materialStock != null) {
                        materialStocksToUpdate.Add(new MaterialStock(materialStock.Id, productReceipt.IdMaterial, materialStock.StockQuantity - (productReceipt.Quantity * orderDetail.Quantity)));
                    }
                }
            }

            await _materialStockRepository.UpdateMaterialStock(materialStocksToUpdate, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return true;
        }
    }
}
