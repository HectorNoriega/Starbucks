using FluentAssertions;
using Moq;
using Moq.Protected;
using Starbucks.Domain.Entities;
using Starbucks.Infrastructure.Repositories;
using Starbucks.Infrastructure.UnitTests.Fixtures;
using Starbucks.Infrastructure.UnitTests.Helpers;

namespace Starbucks.Infrastructure.UnitTests.Systems.Repositories
{
    public class TestTaxRepository
    {
        [Fact]
        public async Task GetTaxes_WhenInvokesHttpGetRequest()
        {
            //Arrange
            var expectedResponse = InfrastructureFixture.getTaxItems();
            var handlerMock = MockHttpMessageHandler<Tax>
                .SetupBasicGetResourceList(expectedResponse);
            var httpClient = new HttpClient(handlerMock.Object);
            var sut = new TaxRepository(httpClient);

            //Act
            var result = await sut.getTaxes();
            
            //Assert
            handlerMock
                .Protected()
                .Verify(
                "SendAsync",
                Times.Exactly(1),
                ItExpr.Is<HttpRequestMessage>(req => req.Method == HttpMethod.Get),
                ItExpr.IsAny<CancellationToken>());

            result.Count.Should().Be(expectedResponse.Count);

        }
    }
}
