using InkWell.Application.Abstractions.Messaging;

namespace InkWell.Application.BusinessLogic.Upvotes.Commands.RemoveUpvote;
public sealed record RemoveUpvoteCommand(Guid CommentId) : ICommand;