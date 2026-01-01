using CqrsMediatR.Commands;
using MediatR;

namespace CqrsMediatR.Handlers
{
    public class UpdateProductHandler : IRequestHandler<UpdateProductCommand, Product>
    {
        private readonly FackDataStore _fackDataStore;
        public UpdateProductHandler(FackDataStore fackDataStore) => _fackDataStore = fackDataStore;
        public async Task<Product> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            await _fackDataStore.UpdateProduct(request.Product);
            return request.Product;
        }
    }
}
