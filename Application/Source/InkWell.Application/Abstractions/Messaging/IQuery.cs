using InkWell.Application.Utilities;
using MediatR;

namespace InkWell.Application.Abstractions.Messaging;

public interface IQuery<TResponse> : IRequest<Result<TResponse>>
{
}