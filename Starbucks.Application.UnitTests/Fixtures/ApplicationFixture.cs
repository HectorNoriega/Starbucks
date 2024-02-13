using Starbucks.Application.Products.Queries.GetProducts;
using Starbucks.Domain.Entities;

namespace Starbucks.Application.UnitTests.Fixtures
{
    public class ApplicationFixture
    {
        public static List<Product> getProductItems() => new List<Product>()
        {
            new(Guid.Parse("cef4bca4-0b28-462a-b653-c0f7bc0b7a86"), "NameProductDTO", "DescriptionProductDTO", 15.5, false),
            new(Guid.Parse("cbaef816-cbb3-4523-937b-4854e35635e0"), "NameProduct2DTO", "DescriptionProduct2DTO", 30.5, true),
        };

        public static List<ProductDTO> getProductItemsDTO() => new List<ProductDTO>()
        {
            new(Guid.Parse("cef4bca4-0b28-462a-b653-c0f7bc0b7a86"), "NameProductDTO", "DescriptionProductDTO", 15.5, false),
            new(Guid.Parse("cbaef816-cbb3-4523-937b-4854e35635e0"), "NameProduct2DTO", "DescriptionProduct2DTO", 30.5, true),
        };

        public static List<MaterialStock> getMaterialStockItems() => new List<MaterialStock>()
        {
             new
                (
                    Guid.Parse("3e30c967-b220-43b9-a041-526e1f6ec753"),
                    Guid.Parse("c2b44be6-0158-47c4-9549-cef4cdc01f5e"), //Leche deslactosada
                    150
                    ),
                new
                (
                     Guid.Parse("26523f6c-c5d3-4e7c-afc5-24775f17cc0f"),
                   Guid.Parse("e271c8a3-1c7d-4f0b-9f24-d589d96be9de"), // Cafe
                    150
                ),
                  new
                (
                     Guid.Parse("a83aa885-d301-4209-a99c-58f1d8863d17"),
                   Guid.Parse("78f2f17b-1df0-472b-818f-dea8a7696dc2"), //Chocolate
                    100
                ),
                    new
                (
                     Guid.Parse("da330d3c-652f-4ed8-99cb-f8535aa7263f"),
                   Guid.Parse("7961ad2a-af88-41cc-b7ed-6de8b805699c"), //Azucar
                    300
                ),
                     new (
                     Guid.Parse("9f12ee6a-e565-477e-8198-cf1daf06c56d"),
                   Guid.Parse("0275ed5b-2e7e-42fd-9729-e612311466e4"), //Te
                    300
                ),
        };

        public static List<ProductReceipt> getProductReceiptItems() => new List<ProductReceipt>()
        {
             new(
                    Guid.Parse("e288c80f-839a-469e-a8b2-15c1432f0550"),
                    Guid.Parse("be889cc3-bf57-41d0-8ca8-d75746b3e39d"), //Frapucchino Mocca
                    Guid.Parse("c2b44be6-0158-47c4-9549-cef4cdc01f5e"), //Leche
                    300),
                new(
                    Guid.Parse("6a8b58fc-31d0-49d1-869f-f20d01c968da"),
                    Guid.Parse("be889cc3-bf57-41d0-8ca8-d75746b3e39d"), //Frapucchino Mocca
                    Guid.Parse("e271c8a3-1c7d-4f0b-9f24-d589d96be9de"), //Cafe
                    200),
                new(
                    Guid.Parse("65aa2ae7-a5d8-4df0-83a5-19e12d6bf2ac"),
                    Guid.Parse("be889cc3-bf57-41d0-8ca8-d75746b3e39d"), //Frapucchino Mocca
                    Guid.Parse("7961ad2a-af88-41cc-b7ed-6de8b805699c"), //Azucar
                    300),
                new(
                    Guid.Parse("52e21e5b-c248-4cba-9aef-d29677a8c004"),
                    Guid.Parse("be889cc3-bf57-41d0-8ca8-d75746b3e39d"), //Frapucchino Mocca
                    Guid.Parse("78f2f17b-1df0-472b-818f-dea8a7696dc2"), //Chocolate
                    100),
        };

        public static List<OrderDetail> getOrderDetailItems() => new List<OrderDetail>()
        {
             new(
                    Guid.Parse("e288c80f-839a-469e-a8b2-15c1432f0550"),
                    Guid.Parse("be889cc3-bf57-41d0-8ca8-d75746b3e39d"),
                    Guid.Parse("c2b44be6-0158-47c4-9549-cef4cdc01f5e"),
                    300),
                new(
                    Guid.Parse("6a8b58fc-31d0-49d1-869f-f20d01c968da"),
                    Guid.Parse("be889cc3-bf57-41d0-8ca8-d75746b3e39d"), 
                    Guid.Parse("e271c8a3-1c7d-4f0b-9f24-d589d96be9de"),
                    200),
                new(
                    Guid.Parse("65aa2ae7-a5d8-4df0-83a5-19e12d6bf2ac"),
                    Guid.Parse("be889cc3-bf57-41d0-8ca8-d75746b3e39d"), 
                    Guid.Parse("7961ad2a-af88-41cc-b7ed-6de8b805699c"),
                    300),
                new(
                    Guid.Parse("52e21e5b-c248-4cba-9aef-d29677a8c004"),
                    Guid.Parse("be889cc3-bf57-41d0-8ca8-d75746b3e39d"), 
                    Guid.Parse("78f2f17b-1df0-472b-818f-dea8a7696dc2"), 
                    100),
        };
    }
}
