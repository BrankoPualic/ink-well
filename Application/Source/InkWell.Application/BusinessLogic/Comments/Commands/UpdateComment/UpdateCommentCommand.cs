using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos.Comment;

namespace InkWell.Application.BusinessLogic.Comments.Commands.UpdateComment;
public sealed record UpdateCommentCommand(Guid CommentId, EntryUpdateCommentDto Comment) : ICommand;