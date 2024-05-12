using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos.User;

namespace InkWell.Application.BusinessLogic.Users.Commands.Signin;
public sealed record SigninCommand(SigninDto User) : ICommand<AuthResponseDto>;