using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos.User;

namespace InkWell.Application.BusinessLogic.Users.Commands.Signup;
public sealed record SignupCommand(SignupDto User) : ICommand<AuthResponseDto>;