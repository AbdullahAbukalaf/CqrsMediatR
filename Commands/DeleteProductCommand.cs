using MediatR;

namespace CqrsMediatR.Commands
{
    public record DeleteProductCommand(int Id) : IRequest;
}
