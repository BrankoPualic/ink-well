using InkWell.Application.Abstractions.Messaging;

namespace InkWell.Application.BusinessLogic.Posts.Commands.DeletePost;
public sealed record DeletePostCommand(Guid Id) : ICommand;