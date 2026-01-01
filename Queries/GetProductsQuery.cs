using MediatR;

namespace CqrsMediatR.Queries
{
    public record GetProductsQuery() : IRequest<IEnumerable<Product>>;
}
