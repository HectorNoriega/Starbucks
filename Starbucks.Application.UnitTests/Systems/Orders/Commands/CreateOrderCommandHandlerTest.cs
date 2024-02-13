using FluentAssertions;
using Moq;
using Starbucks.Application.Orders.Commands;
using Starbucks.Application.UnitTests.Fixtures;
using Starbucks.Domain.Abstractions;
using Starbucks.Domain.Entities;
using Starbucks.Domain.Enums;
using Starbucks.Domain.Repositories;
using Starbucks.Infrastructure.Repositories;

namespace Starbucks.Application.UnitTests.Systems.Orders.Commands
{
    public class CreateOrderCommandHandlerTest
    {
        private readonly Mock<IOrderRepository> _orderRepository;
        private readonly Mock<IProductRepository> _productRepository;
        private readonly Mock<IMaterialStockRepository> _materialStockRepository;
        private readonly Mock<IOrderDetailRepository> _orderDetailRepository;
        private readonly Mock<IProductReceiptRepository> _productReceiptRepository;
        private readonly Mock<IUnitOfWork> _unitOfWork;

        public CreateOrderCommandHandlerTest()
        {
            _orderRepository = new();
            _productRepository = new();
            _materialStockRepository = new();
            _orderDetailRepository = new();
            _productReceiptRepository = new();
            _unitOfWork = new();
        }

        [Fact]
        public async Task Handle_ShouldReturnResult()
        {
            //Arrange
            var creaOrderRequestList = new List<CreateOrderDetailRequest>() 
            { 
               new(Guid.Parse("cef4bca4-0b28-462a-b653-c0f7bc0b7a86"), 1),
               new(Guid.Parse("cbaef816-cbb3-4523-937b-4854e35635e0"), 2),
            };

            var command = new CreateOrderCommand("TestClientName", "TestCajero", creaOrderRequestList);

            var productItems = ApplicationFixture.getProductItems();
            var productItemsDTO = ApplicationFixture.getProductItemsDTO();
            var materialStockItems = ApplicationFixture.getMaterialStockItems();
            var productReceiptItems = ApplicationFixture.getProductReceiptItems();
            var orderDetails = ApplicationFixture.getOrderDetailItems();
            var uuid = Guid.NewGuid();
            var order = new Order(uuid, "TestClientName", "TestCajero", DateTime.Now, OrderStatusEnum.PENDING);

            _orderRepository
                .Setup(service => service
                .AddOrder(order, default));

            _orderDetailRepository
                .Setup(service => service
                .AddOrdersDetails(orderDetails, default));

            _productRepository
                .Setup(service => service
                .GetProducts(default))
                .ReturnsAsync(productItems);

            _materialStockRepository
                 .Setup(service => service
                .GetMaterialsStock(default))
                .ReturnsAsync(materialStockItems);

            _productReceiptRepository
                 .Setup(service => service
                .GetReceiptByProductId(Guid.Parse("cef4bca4-0b28-462a-b653-c0f7bc0b7a86"),default))
                .ReturnsAsync(productReceiptItems);

            var sut = new CreateOrderCommandHandler(
                _orderRepository.Object
                , _orderDetailRepository.Object
                 , _unitOfWork.Object
                  , _materialStockRepository.Object
                   , _productRepository.Object
                    , _productReceiptRepository.Object
                );

            //Act
            var result = await sut.Handle(command, default);

            //Assert
            _productRepository.Verify(
                x => 
                x.GetProducts(
                    It.IsAny<CancellationToken>())
                );
            _productReceiptRepository.Verify(
                x => 
                x.GetReceiptByProductId(
                It.IsAny<Guid>(), 
                It.IsAny<CancellationToken>())
            );

            _materialStockRepository.Verify(
                x=> 
                x.GetMaterialsStock(
                     It.IsAny<CancellationToken>()
                    )
                );

            _orderRepository.Verify(
                x =>
                x.AddOrder(
               It.IsAny<Order>(),
               It.IsAny<CancellationToken>())
           );
            _orderDetailRepository.Verify(
              x =>
              x.AddOrdersDetails(
             It.IsAny<List<OrderDetail>>(),
             It.IsAny<CancellationToken>())
         );
        }
    }
}
