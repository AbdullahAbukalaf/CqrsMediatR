using MediatR;

namespace CqrsMediatR.behaviors
{
    public class LoggingBehavior<Trequest, TResponse> : IPipelineBehavior<Trequest, TResponse>
        where Trequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehavior<Trequest, TResponse>> _logger;
        public LoggingBehavior(ILogger<LoggingBehavior<Trequest, TResponse>> logger) => _logger = logger;
        public async Task<TResponse> Handle(Trequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"Handling { typeof(Trequest).Name}");
            var response = await next(); 
            _logger.LogInformation($"Handled { typeof(TResponse).Name}");
            return response;
        }
    }
}
