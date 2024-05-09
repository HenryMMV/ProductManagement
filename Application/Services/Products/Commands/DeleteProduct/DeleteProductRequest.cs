using Domain.Models.DTOs;
using MediatR;

namespace Application.Services.Products.Commands.DeleteProduct
{
    public class DeleteProductRequest : IRequest<ProductResponse>
    {
        public DeleteProductRequest(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; set; }
    }
}
