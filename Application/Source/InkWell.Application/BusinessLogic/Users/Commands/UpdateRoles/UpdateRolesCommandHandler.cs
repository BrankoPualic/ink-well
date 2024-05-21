using FluentValidation;
using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos.Role;
using InkWell.Application.Identity.Extensions;
using InkWell.Application.Utilities;
using InkWell.Common.Enums;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;

namespace InkWell.Application.BusinessLogic.Users.Commands.UpdateRoles;

internal class UpdateRolesCommandHandler : BaseHandler<RoleDto>, ICommandHandler<UpdateRolesCommand>
{
	public UpdateRolesCommandHandler(IUnitOfWork unitOfWork, IValidator<RoleDto> validator) : base(unitOfWork, validator)
	{
	}

	public async Task<Result> Handle(UpdateRolesCommand request, CancellationToken cancellationToken)
	{
		var validationResult = await Validator.ValidateAsync(request.Roles, cancellationToken);

		if (!validationResult.IsValid)
		{
			return ValidationError.FailureWithValidationResult(validationResult);
		}

		var user = await UnitOfWork.UserRepository.GetUserByIdAsync(request.UserId, cancellationToken);

		if (user is null)
		{
			return Result.Failure(Error<User>.NotFound);
		}

		var currentRoles = await UnitOfWork.RoleRepository.GetUserRolesAsync(request.UserId, cancellationToken);
		var currentRoleNames = currentRoles.Select(ur => ur.Role.Name).ToList();
		var requestedRoleNames = request.Roles.Roles;

		if (requestedRoleNames.OrderBy(r => r).SequenceEqual(currentRoleNames.OrderBy(r => r)))
		{
			return Result.Success();
		}

		var existingRoleNames = currentRoles.Select(ur => ur.Role.Name).ToList();
		var allSystemRoles = await UnitOfWork.RoleRepository.GetAllAsync(cancellationToken);

		foreach (var roleName in requestedRoleNames)
		{
			var userRole = currentRoles.SingleOrDefault(ur => ur.Role.Name.Equals(roleName));

			if (userRole is not null)
			{
				userRole.IsActive = true;
				UnitOfWork.SetEntityStateToModified(user);
			}
			else
			{
				var newRole = new UserRole()
				{
					UserId = request.UserId,
					RoleId = allSystemRoles.Where(x => x.Name.Equals(roleName)).Select(x => x.Id).SingleOrDefault(),
					IsActive = true
				};

				UnitOfWork.SetEntityStateToModified(user);

				UnitOfWork.RoleRepository.AddUserRole(newRole);
			}
		}

		foreach (var currentRole in currentRoles)
		{
			if (!requestedRoleNames.Contains(currentRole.Role.Name))
			{
				currentRole.IsActive = false;
			}
		}

		Audit log = new()
		{
			Id = Guid.NewGuid(),
			EntitiyId = request.UserId,
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