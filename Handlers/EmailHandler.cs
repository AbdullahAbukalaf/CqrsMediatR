using CqrsMediatR.Notifications;
using MediatR;

namespace CqrsMediatR.Handlers
{
    public class EmailHandler : INotificationHandler<ProductAddedNotification>
    {
        private readonly FackDataStore _fackDataStore;
        public EmailHandler(FackDataStore fackDataStore) => _fackDataStore = fackDataStore;
        public async Task Handle(ProductAddedNotification notification, CancellationToken cancellationToken)
        {
            await _fackDataStore.EventOccured(notification.Product, "Email sent");
            await Task.CompletedTask; 
        }
    }
}
