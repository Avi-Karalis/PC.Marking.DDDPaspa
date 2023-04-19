using Domain.Shared;
using MediatR;

namespace Application.Commands;

public interface ICommand : IRequest<Result>
{

}
public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{

}
