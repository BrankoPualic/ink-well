using InkWell.Application.Abstractions.Messaging;

namespace InkWell.Application.BusinessLogic.Comments.Commands.DeleteComment;
public sealed record DeleteCommentCommand(Guid CommentId) : ICommand;