using FluentValidation;
using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos.User;
using InkWell.Application.Identity.Extensions;
using InkWell.Application.Utilities;
using InkWell.Common.Enums;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;

namespace InkWell.Application.BusinessLogic.Users.Commands.Update;

internal class UpdateUserCommandHandler : BaseHandler<EntryUpdateUserDto>, ICommandHandler<UpdateUserCommand>
{
	public UpdateUserCommandHandler(IUnitOfWork unitOfWork, IValidator<EntryUpdateUserDto> validator) : base(unitOfWork, validator)
	{
	}

	public async Task<Result> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
	{
		var validationResult = await Validator.ValidateAsync(request.UpdateUserDto, cancellationToken);

		if (!validationResult.IsValid)
		{
			return ValidationError.FailureWithValidationResult(validationResult);
		}

		var user = await UnitOfWork.UserRepository.GetUserByIdAsync(UserContext.CurrentUserId, cancellationToken);

		if (user is null)
		{
			return Result.Failure(Error<User>.NotFound);
		}

		user.FirstName = request.UpdateUserDto.FirstName;
		user.LastName = request.UpdateUserDto.LastName;
		user.DateOfBirth = request.UpdateUserDto.DateOfBirth;
		//user.ProfilePictureUrl = treba servic za uploud slike

		Audit log = new()
		{
			Id = Guid.NewGuid(),
			EntitiyId = UserContext.CurrentUserId,
			EntitiyTypeId = (int)eEntityType.User,
			ActionTypeId = (int)eActionType.Update,
			IsSuccess = true,
			Time = DateTime.UtcNow,
			ExecutedBy = UserContext.CurrentUserId,
		};

		UnitOfWork.AuditRepository.Add(log);

		if (await UnitOfWork.Complete())
		{
			return Result.Success();
		}

		return Result.Failure(Error.SaveChangesFailed);
	}
}