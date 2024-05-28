using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos.Comment;

namespace InkWell.Application.BusinessLogic.Comments.Commands.CreateComment;
public sealed record CreateCommentCommand(EntryCommentDto Comment) : ICommand;