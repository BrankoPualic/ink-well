using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos.Like;

namespace InkWell.Application.BusinessLogic.Likes.Commands.LikePost;
public sealed record LikePostCommand(LikeDto Like) : ICommand;