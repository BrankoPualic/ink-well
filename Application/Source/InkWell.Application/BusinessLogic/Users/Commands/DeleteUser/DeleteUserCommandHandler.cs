using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Identity.Extensions;
using InkWell.Application.Utilities;
using InkWell.Common.Enums;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;

namespace InkWell.Application.BusinessLogic.Users.Commands.DeleteUser;

internal class DeleteUserCommandHandler : BaseHandler, ICommandHandler<DeleteUserCommand>
{
	public DeleteUserCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
	{
	}

	public async Task<Result> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
	{
		var user = await UnitOfWork.UserRepository.GetUserByIdAsync(request.UserId, cancellationToken);

		if (user is null)
		{
			return Result.Failure(Error<User>.NotFound);
		}

		user.IsActive = false;
		user.DeletedAt = DateTime.UtcNow;
		user.DeletedBy = UserContext.CurrentUserId;

		var roles = await UnitOfWork.RoleRepository.GetUserRolesAsync(request.UserId, cancellationToken);
		foreach (var role in roles)
		{
			role.IsActive = false;
		}

		Audit log = new()
		{
			Id = Guid.NewGuid(),
			EntityId = request.UserId,
			EntityTypeId = (int)eEntityType.User,
			ActionTypeId = (int)eActionType.Delete,
			IsSuccess = true,
			Time = DateTime.UtcNow,
			ExecutedBy = UserContext.CurrentUserId
		};

		UnitOfWork.AuditRepository.Add(log);

		if (await UnitOfWork.Complete())
		{
			return Result.Success();
		}

		return Result.Failure(Error.SaveChangesFailed);
	}
}