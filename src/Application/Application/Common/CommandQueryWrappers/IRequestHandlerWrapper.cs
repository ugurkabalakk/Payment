using MediatR;

namespace Application.Common.CommandQueryWrappers
{
    public interface IRequestHandlerWrapper<TIn, TOut> : IRequestHandler<TIn, TOut>
        where TIn : IRequestWrapper<TOut>
    {
    }
}