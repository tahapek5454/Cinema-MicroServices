using MediatR;

namespace SharedLibrary.Behaviors
{
    public class BeforeHandlerBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            //TODO: Add some logic

            await Console.Out.WriteLineAsync("Before Handler.");

            return await next();
        }
    }
}
