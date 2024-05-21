using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos.User;

namespace InkWell.Application.BusinessLogic.Users.Commands.Update;
public sealed record UpdateUserCommand(EntryUpdateUserDto UpdateUserDto) : ICommand;