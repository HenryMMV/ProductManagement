using Application.Services.Products.Commands.AddProduct;
using Application.Services.Products.Commands.DeleteProduct;
using Application.Services.Products.Commands.UpdateProduct;
using Application.Services.Products.Queries.GetProducts;
using Application.Services.Products.Queries.GetProductsByFilter;
using Domain.Notifications;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Authorize]
    public class ProductController : MainController
    {
        public ProductController(INotifier notifier, IMediator mediator) : base(notifier, mediator)
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProducts()
        {
            var response = await mediator.Send(new GetProductsRequest());
            return CustomResponse(response);
        }

        [HttpPost("products-by-filter")]
        public async Task<IActionResult> GetProductsByFilter(GetProductsByFilterRequest request)
        {
            var response = await mediator.Send(request);
            return CustomResponse(response);
        }

        [HttpPost("add-product")]
        public async Task<IActionResult> AddProduct(AddProductRequest request)
        {
            var response = await mediator.Send(request);
            return CustomResponse(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductRequest request)
        {
            var response = await mediator.Send(request);
            return CustomResponse(response);
        }

        [HttpDelete("{productId}")]
        public async Task<IActionResult> DeleteProduct(Guid productId)
        {
            var response = await mediator.Send(new DeleteProductRequest(productId));
            return CustomResponse(response);
        }
    }
}
