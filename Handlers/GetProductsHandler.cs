using CqrsMediatR.Queries;
using MediatR;

namespace CqrsMediatR.Handlers
{
    public class GetProductsHandler : IRequestHandler<GetProductsQuery, IEnumerable<Product>>
    {
        private readonly FackDataStore _dataStore;
        public GetProductsHandler(FackDataStore fackDataStore) => _dataStore = fackDataStore;
        public async Task<IEnumerable<Product>> Handle(GetProductsQuery request, CancellationToken cancellationToken) => await _dataStore.GetAllProducts();
    }
}
