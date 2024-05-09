using Domain.Models.DTOs;
using MediatR;

namespace Application.Services.Products.Queries.GetProductsByFilter
{
    public class GetProductsByFilterRequest : IRequest<IEnumerable<ProductResponse>>
    {
        public string Name { get; set; }
        public decimal PriceMin { get; set; }
        public decimal PriceMax { get; set; }
    }
}
