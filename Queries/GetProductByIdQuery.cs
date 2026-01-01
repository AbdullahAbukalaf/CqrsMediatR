using MediatR;

namespace CqrsMediatR.Queries
{
    public record GetProductByIdQuery(int id) : IRequest<Product>;
}
