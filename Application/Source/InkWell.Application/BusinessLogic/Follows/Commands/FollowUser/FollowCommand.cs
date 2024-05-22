using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos.Follow;

namespace InkWell.Application.BusinessLogic.Follows.Commands.FollowUser;
public sealed record FollowUserCommand(FollowDto Follow) : ICommand;