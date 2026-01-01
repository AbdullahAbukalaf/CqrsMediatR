using CqrsMediatR.Commands;
using MediatR;

namespace CqrsMediatR.Handlers
{
    public class DeleteProductHandler : IRequestHandler<DeleteProductCommand>
    {   
        private readonly FackDataStore _fackDataStore;
        public DeleteProductHandler(FackDataStore fackDataStore) => _fackDataStore = fackDataStore;
        public async Task Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _fackDataStore.DeleteProduct(request.Id);
            return;
        }
    }
}
