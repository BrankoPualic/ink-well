using FluentValidation;
using InkWell.Application.Dtos.Role;
using InkWell.Domain.Repositories;

namespace InkWell.Application.BusinessLogic.Users.Commands.UpdateRoles;

public class UpdateRolesCommandValidator : AbstractValidator<RoleDto>
{
	public UpdateRolesCommandValidator(IUnitOfWork unitOfWork)
	{
		RuleFor(x => x.Roles)
			.NotEmpty().WithMessage("At least one role is required.")
			.MustAsync(async (roles, cancellationToken) =>
			{
				bool exist = await unitOfWork.RoleRepository.RolesExistAsync(roles, cancellationToken);

				return !exist;
			}).WithMessage("One or more roles does not exist.");
	}
}