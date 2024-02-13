using Starbucks.Application.Products.Queries.GetProducts;

namespace Starbucks.Presentation.UnitTests.Fixtures
{
    public class PresentationFixture
    {
        public static List<ProductDTO> getProductItemsDTO() => new List<ProductDTO>()
        {
            new(Guid.Parse("cef4bca4-0b28-462a-b653-c0f7bc0b7a86"), "NameProductDTO", "DescriptionProductDTO", 15.5, false),
            new(Guid.Parse("cbaef816-cbb3-4523-937b-4854e35635e0"), "NameProduct2DTO", "DescriptionProduct2DTO", 30.5, true),
        };
    }
}
