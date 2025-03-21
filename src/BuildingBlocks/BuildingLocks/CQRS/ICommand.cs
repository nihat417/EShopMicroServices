using MediatR;

namespace BuildingLocks.CQRS
{
    public interface ICommand:ICommand<Unit>
    {}

    public interface ICommand<out TResponse>:IRequest<TResponse>
    {
    }
}
