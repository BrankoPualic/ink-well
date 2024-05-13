using AutoMapper;
using FluentValidation;
using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos.User;
using InkWell.Application.Identity.Abstractions;
using InkWell.Application.Identity.Services;
using InkWell.Application.Utilities;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;

namespace InkWell.Application.BusinessLogic.Users.Commands.Signin;

public class SigninCommandHandler : BaseHandler<SigninDto>, ICommandHandler<SigninCommand, AuthResponseDto>
{
	private IJwtService _jwtService;

	public SigninCommandHandler(
		IUnitOfWork unitOfWork,
		IMapper mapper,
		IValidator<SigninDto> validator,
		IJwtService jwtService) : base(unitOfWork, mapper, validator)
	{
		_jwtService = jwtService;
	}

	public IJwtService JwtService => _jwtService;

	public async Task<Result<AuthResponseDto>> Handle(SigninCommand request, CancellationToken cancellationToken)
	{
		var validationResult = await Validator.ValidateAsync(request.User, cancellationToken);

		if (!validationResult.IsValid)
		{
			return ValidationError.FailureWithValidationResult<AuthResponseDto>(validationResult);
		}

		var user = await UnitOfWork.UserRepository.GetUserByEmailAsync(request.User.Email, cancellationToken);

		if (user is null)
		{
			return Result.Failure<AuthResponseDto>(Error<User>.NotFound);
		}

		bool passwordsMatch = UserService.VerifyPassword(request.User.Password, user.Password);

		if (!passwordsMatch)
		{
			return Result.Failure<AuthResponseDto>(Error<User>.NotFound);
		}

		SigninLog log = new()
		{
			SessionId = Guid.NewGuid(),
			UserId = user.Id,
			Time = DateTime.UtcNow,
		};

		UnitOfWork.SigninLogRepository.Add(log);

		if (await UnitOfWork.Complete())
		{
			var roles = user.UserRoles.Select(ur => ur.Role.Name).ToArray();

			var userMapped = Mapper.Map<AuthResponseDto>(user);
			userMapped.Token = JwtService.GenerateJwtToken(user.Id, roles);

			return Result.Success(userMapped);
		}

		return Result.Failure<AuthResponseDto>(Error.ServerError);
	}
}