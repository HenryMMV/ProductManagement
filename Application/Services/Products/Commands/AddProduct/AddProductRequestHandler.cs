using Domain.Interfaces;
using Domain.Models.DTOs;
using Domain.Models.Entities;
using Domain.Notifications;

namespace Application.Services.Products.Commands.AddProduct
{
    public class AddProductRequestHandler : RequestHandlerBase<AddProductRequest, ProductResponse>
    {
        private readonly IProductRepository _productRepository;
        public AddProductRequestHandler(INotifier notifier, IProductRepository productRepository) : base(notifier)
        {
            _productRepository = productRepository;
        }

        public async override Task<ProductResponse> Handle(AddProductRequest request, CancellationToken cancellationToken)
        {
            var product = ParseToProduct(request);
            await _productRepository.AddProduct(product);
            return ParseToProductResponse(product);
        }

        private static Product ParseToProduct(AddProductRequest request)
        {
            return new Product
            {
                Name = request.Name,
                Description = request.Description,
                Category = request.Category,
                Price = request.Price,
                Quantity = request.Quantity,
            };
        }

        private static ProductResponse ParseToProductResponse(Product product)
        {
            return new ProductResponse
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Category = product.Category,
                Price = product.Price,
                Quantity = product.Quantity,
            };
        }
    }
}
