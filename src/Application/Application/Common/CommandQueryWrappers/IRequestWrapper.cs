using MediatR;

namespace Application.Common.CommandQueryWrappers
{
    public interface IRequestWrapper<T> : IRequest<T>
    {
    }
}