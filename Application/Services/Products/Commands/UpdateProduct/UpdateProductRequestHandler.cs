using Domain.Interfaces;
using Domain.Models.DTOs;
using Domain.Models.Entities;
using Domain.Notifications;

namespace Application.Services.Products.Commands.UpdateProduct
{
    public class UpdateProductRequestHandler : RequestHandlerBase<UpdateProductRequest, ProductResponse>
    {
        private readonly IProductRepository _productRepository;
        public UpdateProductRequestHandler(INotifier notifier, IProductRepository productRepository) : base(notifier)
        {
            _productRepository = productRepository;
        }

        public override async Task<ProductResponse> Handle(UpdateProductRequest request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetProductById(request.Id);
            if (product == null)
            {
                Notify("El producto no existe.");
                return new ProductResponse();
            }

            product.Name = request.Name ?? product.Name;
            product.Description = request.Description ?? product.Description;
            product.Category = request.Category ?? product.Category;
            product.Price = request.Price ?? product.Price;
            product.Quantity = request.Quantity ?? product.Quantity;
            
            await _productRepository.UpdateProduct(product);
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
