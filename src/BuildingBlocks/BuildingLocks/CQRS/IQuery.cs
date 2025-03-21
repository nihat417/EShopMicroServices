using MediatR;

namespace BuildingLocks.CQRS
{
    public interface IQuery<out TResponse>:IRequest<TResponse>
        where TResponse : notnull 
    {
    }
}
