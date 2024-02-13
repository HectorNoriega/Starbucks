using Starbucks.Application.Abstractions;

namespace Starbucks.Application.Products.Queries.GetProducts
{
    public sealed record GetProductsQuery() : IQuery<List<ProductDTO>>;
}
