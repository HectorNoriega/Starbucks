using Starbucks.Application.Abstractions;
using Starbucks.Domain.Abstractions;
using Starbucks.Domain.Entities;
using Starbucks.Domain.Enums;
using Starbucks.Domain.Repositories;

namespace Starbucks.Application.Orders.Commands
{
    internal sealed class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand, Guid>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;
        private readonly IMaterialStockRepository _materialStockRepository;
        private readonly IOrderDetailRepository _orderDetailRepository;
        private readonly IProductReceiptRepository _productReceiptRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateOrderCommandHandler(IOrderRepository orderRepository
            , IOrderDetailRepository orderDetailRepository
            , IUnitOfWork unitOfWork
            , IMaterialStockRepository materialStockRepository
            , IProductRepository productRepository
            , IProductReceiptRepository productReceiptRepository)
        {
            _orderRepository = orderRepository;
            _orderDetailRepository = orderDetailRepository;
            _unitOfWork = unitOfWork;
            _materialStockRepository = materialStockRepository;
            _productRepository = productRepository;
            _productReceiptRepository = productReceiptRepository;
        }

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order(Guid.NewGuid(), request.ClientName, request.NameAtention, DateTime.Now, OrderStatusEnum.PENDING);
            var listOrderDetailAccepted = new List<OrderDetail>();

            var materialsStock = await _materialStockRepository.GetMaterialsStock(cancellationToken);
            var products = await _productRepository.GetProducts(cancellationToken);


            foreach (var orderDetailItem in request.Details)
            {
                var orderDetailAccepted = true;
                var productsReceipt = await _productReceiptRepository.GetReceiptByProductId(orderDetailItem.IdProduct, cancellationToken);

                if (productsReceipt != null)
                {
                    foreach (var productReceiptItem in productsReceipt)
                    {
                        var materialStockItem = materialsStock.Where(x => x.IdMaterial == productReceiptItem.IdMaterial).FirstOrDefault();

                        if (materialStockItem != null)
                        {
                            if (materialStockItem.StockQuantity < productReceiptItem.Quantity * orderDetailItem.Quantity)
                            {
                                orderDetailAccepted = false;
                            }
                        }

                    }
                }

                if (orderDetailAccepted)
                    listOrderDetailAccepted.Add(
                                   new OrderDetail(Guid.NewGuid(), order.Id, orderDetailItem.IdProduct, orderDetailItem.Quantity));
            }

            await _orderRepository.AddOrder(order, cancellationToken);
            await _orderDetailRepository.AddOrdersDetails(listOrderDetailAccepted, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return order.Id;
        }
    }
}
