using InkWell.Application.Abstractions.Messaging;

namespace InkWell.Application.BusinessLogic.Likes.Commands.RemoveLike;
public sealed record RemoveLikeCommand(Guid PostId) : ICommand;