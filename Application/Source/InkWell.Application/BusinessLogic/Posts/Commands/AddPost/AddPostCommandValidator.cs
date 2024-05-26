using FluentValidation;
using InkWell.Application.Dtos.Post;
using InkWell.Domain.Repositories;

namespace InkWell.Application.BusinessLogic.Posts.Commands.AddPost;

public class AddPostCommandValidator : AbstractValidator<EntryPostDto>
{
	public AddPostCommandValidator(IUnitOfWork unitOfWork)
	{
		RuleFor(x => x.Title)
			.NotEmpty().WithMessage("Title is required.")
			.MaximumLength(50).WithMessage("Title can't be more than 50 characters.");

		RuleFor(x => x.Description)
			.NotEmpty().WithMessage("Description is required.")
			.MaximumLength(255).WithMessage("Description can't be more than 255 characters.");

		RuleFor(x => x.Text)
			.NotEmpty().WithMessage("Text is required.");

		RuleFor(x => x.PostImage)
			.NotEmpty().WithMessage("Image is required.");

		RuleFor(x => x.CategoryId)
			.NotEmpty().WithMessage("Category id is required.")
			.MustAsync(async (categoryId, cancellationToken) =>
			{
				return await unitOfWork.CategoryRepository.CategoryExistByIdAsync(categoryId, cancellationToken);
			}).WithMessage("Category not found.");
	}
}