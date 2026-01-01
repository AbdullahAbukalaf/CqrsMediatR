using CqrsMediatR.Queries;
using MediatR;

namespace CqrsMediatR.Handlers
{
    public class GetProductByIdHandler : IRequestHandler<GetProductByIdQuery, Product>
    {
        private readonly FackDataStore _fackDataStore;
        public GetProductByIdHandler(FackDataStore fackDataStore) => _fackDataStore = fackDataStore;
        public async Task<Product> Handle(GetProductByIdQuery request, CancellationToken cancellationToken) => await _fackDataStore.GetProductById(request.id);
    }
}
