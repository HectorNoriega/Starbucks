using Starbucks.Application.Abstractions;
using Starbucks.Domain.Repositories;

namespace Starbucks.Application.Products.Queries.GetProducts
{
    public sealed class GetProductsQueryHandler : IQueryHandler<GetProductsQuery, List<ProductDTO>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<List<ProductDTO>> Handle(GetProductsQuery request, CancellationToken cancellationToken)
        {
            var listProductsDTO = new List<ProductDTO>();

            var products = await _productRepository.GetProducts(cancellationToken);

            foreach (var product in products)
            {
                listProductsDTO.Add(new ProductDTO(product.Id, product.Name, product.Description, product.Price, product.Status));
            }

            return listProductsDTO;
        }
    }
}
