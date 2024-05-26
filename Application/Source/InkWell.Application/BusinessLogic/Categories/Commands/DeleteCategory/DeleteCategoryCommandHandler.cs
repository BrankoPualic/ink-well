using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Helpers;
using InkWell.Application.Identity.Extensions;
using InkWell.Application.Utilities;
using InkWell.Common.Enums;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;

namespace InkWell.Application.BusinessLogic.Categories.Commands.DeleteCategory;

internal class DeleteCategoryCommandHandler : BaseHandler, ICommandHandler<DeleteCategoryCommand>
{
	public DeleteCategoryCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
	{
	}

	public async Task<Result> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
	{
		var category = await UnitOfWork.CategoryRepository.GetCategoryByIdAsync(request.Id, cancellationToken);

		if (category is null)
		{
			return Result.Failure(Error<Category>.NotFound);
		}

		category.IsActive = false;
		category.DeletedAt = DateTime.UtcNow;
		category.DeletedBy = UserContext.CurrentUserId;

		Audit log = new()
		{
			Id = Guid.NewGuid(),
			EntitiyId = category.Id,
			EntitiyTypeId = (int)eEntityType.Category,
			ActionTypeId = (int)eActionType.Delete,
			IsSuccess = true,
			Time = DateTime.UtcNow,
			ExecutedBy = UserContext.CurrentUserId,
		};

		UnitOfWork.AuditRepository.Add(log);

		if (category.Children.Count > 0)
		{
			CommandHelpers.DeactivateCategoryChildren(category.Children, UnitOfWork);
		}

		return await UnitOfWork.Complete()
			? Result.Success()
			: Result.Failure(Error.SaveChangesFailed);
	}
}