using FluentValidation;
using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos.User;
using InkWell.Application.Identity.Extensions;
using InkWell.Application.Utilities;
using InkWell.Common.Enums;
using InkWell.Common.Storage;
using InkWell.Domain.Abstractions;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;

namespace InkWell.Application.BusinessLogic.Users.Commands.Update;

internal class UpdateUserCommandHandler : BaseHandler<EntryUpdateUserDto>, ICommandHandler<UpdateUserCommand>
{
	private readonly ICloudinaryStorage _cloudinaryStorage;

	public UpdateUserCommandHandler(
		IUnitOfWork unitOfWork,
		IValidator<EntryUpdateUserDto> validator,
		ICloudinaryStorage cloudinaryStorage)
		: base(unitOfWork, validator)
	{
		_cloudinaryStorage = cloudinaryStorage;
	}

	public ICloudinaryStorage Cloudinary => _cloudinaryStorage;

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

		if (request.UpdateUserDto.ProfilePicture is not null)
		{
			var file = new FormFileAdapter(request.UpdateUserDto.ProfilePicture);
			try
			{
				var imageUploadResult = await Cloudinary.UploadPhotoAsync(file);

				if (user.ProfilePictureUrl is not null)
				{
					var deletion = await Cloudinary.DeletePhotoAsync(user.PublicId!);
				}

				user.ProfilePictureUrl = imageUploadResult.Url;
				user.PublicId = imageUploadResult.PublicId;
			}
			catch (Exception ex)
			{
				return Result.Failure(Error.ServerError);
			}
		}
		else
		{
			try
			{
				var deletion = await Cloudinary.DeletePhotoAsync(user.PublicId!);
				user.ProfilePictureUrl = null;
				user.PublicId = null;
			}
			catch (Exception ex)
			{
				return Result.Failure(Error.ServerError);
			}
		}

		user.FirstName = request.UpdateUserDto.FirstName;
		user.LastName = request.UpdateUserDto.LastName;
		user.DateOfBirth = request.UpdateUserDto.DateOfBirth;

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