using CqrsMediatR.Commands;
using MediatR;

namespace CqrsMediatR.Handlers
{
    //public class AddProductHandler : IRequestHandler<AddProductCommand>
    public class AddProductHandler : IRequestHandler<AddProductCommand, Product>
    {
        private readonly FackDataStore _fackDataStore;
        public AddProductHandler(FackDataStore fackDataStore) => _fackDataStore = fackDataStore;

        //public async Task Handle(AddProductCommand request, CancellationToken cancellationToken)
        public async Task<Product> Handle(AddProductCommand request, CancellationToken cancellationToken)
        {
            await _fackDataStore.AddProduct(request.Product);
            //return;
            return request.Product;
        }
    }
}
