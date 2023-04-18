using Domain.Shared;
using MediatR;

namespace Application.Commands.AutoMarkingCommand;

public interface ICommand : IRequest<Result>
{

}
public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{

}
