using FluentValidation;
using InkWell.Application.Dtos.Category;
using InkWell.Domain.Repositories;

namespace InkWell.Application.BusinessLogic.Categories.Commands.AddCategory;

public class AddCategoryCommandValidator : AbstractValidator<EntryCategoryDto>
{
	public AddCategoryCommandValidator(IUnitOfWork unitOfWork)
	{
		RuleFor(x => x.Name)
			.NotEmpty().WithMessage("Name is required.")
			.MustAsync(async (name, cancellationToken) =>
			{
				return !await unitOfWork.CategoryRepository.CategoryExistByNameAsync(name, cancellationToken);
			}).WithMessage("Category with this name already exist.")
			.MaximumLength(20).WithMessage("Name can't be more than 20 characters long.");

		RuleFor(x => x.ParentId)
			.MustAsync(async (parentId, cancellationToken) =>
			{
				return parentId is null
				|| await unitOfWork.CategoryRepository.CategoryExistByIdAsync(parentId, cancellationToken);
			}).WithMessage("Parent category doesn't exist.");
	}
}