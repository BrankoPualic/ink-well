using InkWell.Application.Abstractions.Messaging;

namespace InkWell.Application.BusinessLogic.Users.Commands.DeleteUser;
public sealed record DeleteUserCommand(Guid UserId) : ICommand;