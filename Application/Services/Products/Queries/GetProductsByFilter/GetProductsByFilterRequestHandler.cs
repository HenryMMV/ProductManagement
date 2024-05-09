using Domain.Interfaces;
using Domain.Models.DTOs;
using Domain.Notifications;

namespace Application.Services.Products.Queries.GetProductsByFilter
{
    public class GetProductsByFilterRequestHandler : RequestHandlerBase<GetProductsByFilterRequest, IEnumerable<ProductResponse>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsByFilterRequestHandler(INotifier notifier, IProductRepository productRepository) : base(notifier)
        {
            _productRepository = productRepository;
        }

        public override async Task<IEnumerable<ProductResponse>> Handle(GetProductsByFilterRequest request, CancellationToken cancellationToken)
        {
            var productFilter = ParseToProductFilter(request);
            var products = await _productRepository.FindProducts(productFilter);

            return products.Select(p => new ProductResponse
            {
                Id = p.Id,
                Name = p.Name,
                Description = p.Description,
                Category = p.Category,
                Price = p.Price,
                Quantity = p.Quantity,
            });
        }

        private static ProductFilter ParseToProductFilter(GetProductsByFilterRequest request)
        {
            return new ProductFilter
            {
                Name = request.Name,
                PriceMax = request.PriceMax,
                PriceMin = request.PriceMin,
            };
        }
    }
}
