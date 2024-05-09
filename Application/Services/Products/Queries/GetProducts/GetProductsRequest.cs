using Domain.Models.DTOs;
using MediatR;

namespace Application.Services.Products.Queries.GetProducts
{
    public class GetProductsRequest : IRequest<IEnumerable<ProductResponse>>
    {
    }
}
