using MediatR;

namespace SharedLibrary.Behaviors
{
    public class AfterHandlerBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var result = await next();

            await Console.Out.WriteLineAsync("After Handler");

            return result;
        }
    }
}
