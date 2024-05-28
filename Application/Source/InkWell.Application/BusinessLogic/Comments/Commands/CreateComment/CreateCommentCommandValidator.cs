using FluentValidation;
using InkWell.Application.Dtos.Comment;
using InkWell.Domain.Repositories;

namespace InkWell.Application.BusinessLogic.Comments.Commands.CreateComment;

public class CreateCommentCommandValidator : AbstractValidator<EntryCommentDto>
{
	public CreateCommentCommandValidator(IUnitOfWork unitOfWork)
	{
		RuleFor(x => x.PostId)
			.NotEmpty().WithMessage("Post id is required.")
			.MustAsync(async (postId, cancellationToken) =>
			{
				return await unitOfWork.PostRepository.GetPostByIdAsync(postId, cancellationToken) is not null;
			}).WithMessage("Post doesn't exist.");

		RuleFor(x => x.Title)
			.Must((title) =>
			{
				if (title is not null)
				{
					return title.Length <= 30;
				}

				return true;
			}).WithMessage("Title can't be more than 30 characters.");

		RuleFor(x => x.Text)
			.NotEmpty().WithMessage("Comment text is required.");

		RuleFor(x => x.ParentId)
			.MustAsync(async (parentId, cancellationToken) =>
			{
				if (parentId is null)
				{
					return true;
				}

				return await unitOfWork.CommentRepository.GetCommentByIdAsync(parentId, cancellationToken) is not null;
			}).WithMessage("Parent comment doesn't exist.");
	}
}