using Domain.Shared;
using MediatR;

namespace Application.Queries;

public interface IQuery<TResponse> : IRequest<Result<TResponse>> 
{
}
