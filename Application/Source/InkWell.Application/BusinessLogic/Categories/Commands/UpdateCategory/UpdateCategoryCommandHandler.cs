using FluentValidation;
using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos.Category;
using InkWell.Application.Identity.Extensions;
using InkWell.Application.Utilities;
using InkWell.Common.Enums;
using InkWell.Common.Extensions;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;

namespace InkWell.Application.BusinessLogic.Categories.Commands.UpdateCategory;

internal class UpdateCategoryCommandHandler : BaseHandler<EntryUpdateCategoryDto>, ICommandHandler<UpdateCategoryCommand>
{
	public UpdateCategoryCommandHandler(IUnitOfWork unitOfWork, IValidator<EntryUpdateCategoryDto> validator) : base(unitOfWork, validator)
	{
	}

	public async Task<Result> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
	{
		var validationResult = await Validator.ValidateAsync(request.Cateogry, cancellationToken);

		if (!validationResult.IsValid)
		{
			return ValidationError.FailureWithValidationResult(validationResult);
		}

		var category = await UnitOfWork.CategoryRepository.GetCategoryByIdAsync(request.Id, cancellationToken);

		if (category is null)
		{
			return Result.Failure(Error<Category>.NotFound);
		}

		category.Name = request.Cateogry.Name.HasValue() ? request.Cateogry.Name : category.Name;
		category.ParentId = request.Cateogry.ParentId;
		category.IsActive = request.Cateogry.IsActive || category.IsActive;

		Audit log = new()
		{
			Id = Guid.NewGuid(),
			EntityId = category.Id,
			EntityTypeId = (int)eEntityType.Category,
			ActionTypeId = (int)eActionType.Update,
			IsSuccess = true,
			Time = DateTime.UtcNow,
			ExecutedBy = UserContext.CurrentUserId,
		};

		UnitOfWork.AuditRepository.Add(log);

		return await UnitOfWork.Complete()
			? Result.Success()
			: Result.Failure(Error.SaveChangesFailed);
	}
}