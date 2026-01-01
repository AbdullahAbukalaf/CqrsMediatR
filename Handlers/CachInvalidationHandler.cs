using CqrsMediatR.Notifications;
using MediatR;

namespace CqrsMediatR.Handlers
{
    public class CachInvalidationHandler : INotificationHandler<ProductAddedNotification>
    {
        private readonly FackDataStore _fackDataStore;
        public CachInvalidationHandler(FackDataStore fackDataStore) => _fackDataStore = fackDataStore;
        public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
        {
            await _fackDataStore.EventOccured(notification.Product, "Cache invalidated");
            await Task.CompletedTask;
        }
    
    }
}
