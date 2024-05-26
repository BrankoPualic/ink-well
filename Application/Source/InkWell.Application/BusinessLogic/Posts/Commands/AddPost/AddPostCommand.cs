using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos.Post;

namespace InkWell.Application.BusinessLogic.Posts.Commands.AddPost;
public sealed record AddPostCommand(EntryPostDto Post) : ICommand;