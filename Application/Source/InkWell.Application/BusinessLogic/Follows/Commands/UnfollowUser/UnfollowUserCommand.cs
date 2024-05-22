using InkWell.Application.Abstractions.Messaging;

namespace InkWell.Application.BusinessLogic.Follows.Commands.UnfollowUser;

public sealed record UnfollowUserCommand(Guid FollowingId) : ICommand;