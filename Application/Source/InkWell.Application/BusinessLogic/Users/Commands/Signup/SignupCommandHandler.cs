using AutoMapper;
using FluentValidation;
using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos.User;
using InkWell.Application.Identity.Abstractions;
using InkWell.Application.Identity.Services;
using InkWell.Application.Utilities;
using InkWell.Common.Enums;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;

namespace InkWell.Application.BusinessLogic.Users.Commands.Signup;

public class SignupCommandHandler : BaseHandler<SignupDto>, ICommandHandler<SignupCommand, AuthResponseDto>
{
	private readonly IJwtService _jwtService;

	public SignupCommandHandler(
		IUnitOfWork unitOfWork,
		IMapper mapper,
		IValidator<SignupDto> validator,
		IJwtService jwtService) : base(unitOfWork, mapper, validator)
	{
		_jwtService = jwtService;
	}

	public IJwtService JwtService => _jwtService;

	public async Task<Result<AuthResponseDto>> Handle(SignupCommand request, CancellationToken cancellationToken)
	{
		var validationResult = await Validator.ValidateAsync(request.User, cancellationToken);

		if (!validationResult.IsValid)
		{
			return ValidationError.FailureWithValidationResult<AuthResponseDto>(validationResult);
		}

		var newUserId = Guid.NewGuid();

		User user = new()
		{
			Id = newUserId,
			FirstName = request.User.FirstName,
			LastName = request.User.LastName,
			Email = request.User.Email,
			Username = request.User.Username,
			Password = UserService.HashPassword(request.User.Password),
			//ProfilePictureUrl = request.User.ProfilePictureUrl,  Here needs to be a PhotoService functionality
			DateOfBirth = request.User.DateOfBirth,
			CreatedAt = DateTime.UtcNow,
		};

		UserRole userRole = new()
		{
			UserId = newUserId,
			RoleId = (int)eUserRole.Member,
			IsActive = true
		};

		await UnitOfWork.UserRepository.AddAsync(user, userRole, cancellationToken);

		Audit log = new()
		{
			Id = Guid.NewGuid(),
			EntitiyId = newUserId,
			EntitiyTypeId = (int)eEntityType.User,
			ActionTypeId = (int)eActionType.Insert,
			IsSuccess = true,
			Time = DateTime.UtcNow,
			ExecutedBy = newUserId,
		};

		UnitOfWork.AuditRepository.Add(log);

		if (await UnitOfWork.Complete())
		{
			var userMapped = Mapper.Map<AuthResponseDto>(user);
			userMapped.Token = JwtService.GenerateJwtToken(newUserId, [eUserRole.Member.ToString()]);

			return Result.Success(userMapped);
		}

		return Result.Failure<AuthResponseDto>(Error.SaveChangesFailed);
	}
}