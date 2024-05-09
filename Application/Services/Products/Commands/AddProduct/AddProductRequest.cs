using Domain.Models.DTOs;
using MediatR;

namespace Application.Services.Products.Commands.AddProduct
{
    public class AddProductRequest : IRequest<ProductResponse>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
    }
}
