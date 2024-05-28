using FluentValidation;
using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos.Category;
using InkWell.Application.Identity.Extensions;
using InkWell.Application.Utilities;
using InkWell.Common.Enums;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;

namespace InkWell.Application.BusinessLogic.Categories.Commands.AddCategory;

internal class AddCategoryCommandHandler : BaseHandler<EntryCategoryDto>, ICommandHandler<AddCategoryCommand>
{
	public AddCategoryCommandHandler(IUnitOfWork unitOfWork, IValidator<EntryCategoryDto> validator) : base(unitOfWork, validator)
	{
	}

	public async Task<Result> Handle(AddCategoryCommand request, CancellationToken cancellationToken)
	{
		var validationResult = await Validator.ValidateAsync(request.Category, cancellationToken);

		if (!validationResult.IsValid)
		{
			return ValidationError.FailureWithValidationResult(validationResult);
		}

		Category newCategory = new()
		{
			Id = Guid.NewGuid(),
			Name = request.Category.Name,
			ParentId = request.Category.ParentId,
			IsActive = true,
			CreatedAt = DateTime.UtcNow,
		};

		UnitOfWork.CategoryRepository.AddCategory(newCategory);

		Audit log = new()
		{
			Id = Guid.NewGuid(),
			EntityId = newCategory.Id,
			EntityTypeId = (int)eEntityType.Category,
			ActionTypeId = (int)eActionType.Insert,
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