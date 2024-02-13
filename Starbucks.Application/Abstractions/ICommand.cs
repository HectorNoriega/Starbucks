using MediatR;

namespace Starbucks.Application.Abstractions;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}