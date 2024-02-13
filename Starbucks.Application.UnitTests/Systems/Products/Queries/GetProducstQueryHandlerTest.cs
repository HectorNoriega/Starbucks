using FluentAssertions;
using Moq;
using Starbucks.Application.Products.Queries.GetProducts;
using Starbucks.Application.UnitTests.Fixtures;
using Starbucks.Domain.Entities;
using Starbucks.Domain.Repositories;

namespace Starbucks.Application.UnitTests.Products.Queries
{
    public class GetProducstQueryHandlerTest
    {
        private readonly Mock<IProductRepository> _productRepository;

        public GetProducstQueryHandlerTest()
        {
            _productRepository = new();
        }


        [Fact]
        public async Task Handle_ShouldReturnResult()
        {
            //Arrange
            var command = new GetProductsQuery();
            var sut = new GetProductsQueryHandler(_productRepository.Object);

            var productItems = ApplicationFixture.getProductItems();
            var productItemsDTO = ApplicationFixture.getProductItemsDTO();

            _productRepository
                .Setup(service => service
                .GetProducts(default))
                .ReturnsAsync(productItems);

            //Act
            var result = await sut.Handle(command, default);

            //Assert
            _productRepository.Verify(x => x.GetProducts(It.IsAny<CancellationToken>()));
            result.Should().BeOfType<List<ProductDTO>>();
            result.Should().BeEquivalentTo(productItemsDTO);
        }
    }
}
