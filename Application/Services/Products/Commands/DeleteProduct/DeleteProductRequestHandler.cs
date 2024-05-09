using Domain.Interfaces;
using Domain.Models.DTOs;
using Domain.Models.Entities;
using Domain.Notifications;

namespace Application.Services.Products.Commands.DeleteProduct
{
    public class DeleteProductRequestHandler : RequestHandlerBase<DeleteProductRequest, ProductResponse>
    {
        private readonly IProductRepository _productRepository;
        public DeleteProductRequestHandler(INotifier notifier, IProductRepository productRepository) : base(notifier)
        {
            _productRepository = productRepository;
        }

        public override async Task<ProductResponse> Handle(DeleteProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductById(request.Id);
            if (product == null)
            {
                Notify("El producto no existe.");
                return new ProductResponse();
            }

            await _productRepository.DeleteProduct(product);
            return ParseToProductResponse(product);
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
