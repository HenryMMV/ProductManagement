using Domain.Models.DTOs;
using MediatR;

namespace Application.Services.Products.Commands.UpdateProduct
{
    public class UpdateProductRequest : IRequest<ProductResponse>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Category { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
    }
}
