using InkWell.Application.Utilities;
using MediatR;

namespace InkWell.Application.Abstractions.Messaging;

public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}