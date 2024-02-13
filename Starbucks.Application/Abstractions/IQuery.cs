using MediatR;

namespace Starbucks.Application.Abstractions;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}