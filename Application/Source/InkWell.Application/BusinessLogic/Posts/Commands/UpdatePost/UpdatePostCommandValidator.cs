using FluentValidation;
using InkWell.Application.Dtos.Post;
using InkWell.Domain.Repositories;

namespace InkWell.Application.BusinessLogic.Posts.Commands.UpdatePost;

public class UpdatePostCommandValidator : AbstractValidator<EntryUpdatePostDto>
{
	public UpdatePostCommandValidator(IUnitOfWork unitOfWork)
	{
		RuleFor(x => x.Title)
			.Must((title) =>
			{
				if (title is null)
				{
					return true;
				}
				else if (title.Length > 50)
				{
					return false;
				}
				return true;
			}).WithMessage("Title can't be more than 50 characters.");

		RuleFor(x => x.Description)
			.Must((description) =>
			{
				if (description is null)
				{
					return true;
				}
				else if (description.Length > 255)
				{
					return false;
				}
				return true;
			}).WithMessage("Description can't be more than 255 characters.");

		RuleFor(x => x.CategoryId)
			.MustAsync(async (categoryId, cancellationToken) =>
			{
				if (categoryId is null)
				{
					return true;
				}
				else
				{
					return await unitOfWork.CategoryRepository.CategoryExistByIdAsync(categoryId, cancellationToken);
				}
			}).WithMessage("Category not found.");
	}
}