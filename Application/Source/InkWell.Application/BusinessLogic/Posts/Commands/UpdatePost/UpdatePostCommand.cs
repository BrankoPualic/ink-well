using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos.Post;

namespace InkWell.Application.BusinessLogic.Posts.Commands.UpdatePost;
public sealed record UpdatePostCommand(Guid PostId, EntryUpdatePostDto Post) : ICommand;