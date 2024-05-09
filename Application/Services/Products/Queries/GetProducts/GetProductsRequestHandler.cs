using Domain.Interfaces;
using Domain.Models.DTOs;
using Domain.Notifications;

namespace Application.Services.Products.Queries.GetProducts
{
    public class GetProductsRequestHandler : RequestHandlerBase<GetProductsRequest, IEnumerable<ProductResponse>>
    {
        private readonly IProductRepository _productRepository;

        public GetProductsRequestHandler(INotifier notifier, IProductRepository productRepository) : base(notifier)
        {
            _productRepository = productRepository;
        }

        public override async Task<IEnumerable<ProductResponse>> Handle(GetProductsRequest request, CancellationToken cancellationToken)
        {
            var result = await _productRepository.GetAllProducts();
            return result.Select(x => new ProductResponse
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,
                Category = x.Category,
                Price = x.Price,
                Quantity = x.Quantity,
            });
        }
    }
}
