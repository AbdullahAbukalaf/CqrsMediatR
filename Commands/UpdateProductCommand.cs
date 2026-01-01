using MediatR;

namespace CqrsMediatR.Commands
{
    public record UpdateProductCommand(Product Product) : IRequest<Product>;
}
