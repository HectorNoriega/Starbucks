using FluentAssertions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Starbucks.API.Controllers;
using Starbucks.Application.Products.Queries.GetProducts;
using Starbucks.Presentation.UnitTests.Fixtures;

namespace Starbucks.Presentation.UnitTests.Systems.Controllers
{
    public class TestProductController
    {
        [Fact]
        public async Task GetProducts_OnSuccess()
        {
            //Arrange
            var mockMediator = new Mock<ISender>();
            var query = new GetProductsQuery();
            var productItemsDTO = PresentationFixture.getProductItemsDTO();

            mockMediator.Setup(service => service.Send(query, default)).ReturnsAsync(productItemsDTO);

            var sut = new ProductController(mockMediator.Object);
            
            //Act
            var result =  await sut.GetProducts(new CancellationToken());

            //Assert
            result.Should().BeOfType<OkObjectResult>();
            var objectResult = (OkObjectResult)result;
            objectResult.StatusCode.Should().Be(200);
            mockMediator.Verify(x => x.Send(It.IsAny<GetProductsQuery>(), It.IsAny<CancellationToken>()), Times.Once);
            objectResult.Value.Should().BeOfType<List<ProductDTO>>();
            objectResult.Value.Should().BeEquivalentTo(productItemsDTO);
        }

        [Fact]
        public async Task GetProducts_OnErrorNoContent()
        {
            //Arrange
            var mockMediator = new Mock<ISender>();
            var query = new GetProductsQuery();
            var productItemsDTO = new List<ProductDTO>();

            mockMediator.Setup(service => service.Send(query, default)).ReturnsAsync(productItemsDTO);

            var sut = new ProductController(mockMediator.Object);

            //Act
            var result = await sut.GetProducts(new CancellationToken());

            //Assert
            result.Should().BeOfType<NoContentResult>();
            var objectResult = (NoContentResult)result;
            objectResult.StatusCode.Should().Be(204);
            mockMediator.Verify(x => x.Send(It.IsAny<GetProductsQuery>(), It.IsAny<CancellationToken>()), Times.Once);
        }
    }
}
