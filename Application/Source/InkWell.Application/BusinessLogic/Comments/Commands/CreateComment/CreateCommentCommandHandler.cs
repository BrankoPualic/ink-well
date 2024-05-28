using FluentValidation;
using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos.Comment;
using InkWell.Application.Identity.Extensions;
using InkWell.Application.Utilities;
using InkWell.Common.Enums;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;

namespace InkWell.Application.BusinessLogic.Comments.Commands.CreateComment;

internal class CreateCommentCommandHandler : BaseHandler<EntryCommentDto>, ICommandHandler<CreateCommentCommand>
{
	public CreateCommentCommandHandler(IUnitOfWork unitOfWork, IValidator<EntryCommentDto> validator) : base(unitOfWork, validator)
	{
	}

	public async Task<Result> Handle(CreateCommentCommand request, CancellationToken cancellationToken)
	{
		var validationResult = await Validator.ValidateAsync(request.Comment, cancellationToken);

		if (!validationResult.IsValid)
		{
			return ValidationError.FailureWithValidationResult(validationResult);
		}

		var currentUser = UserContext.CurrentUserId;

		var comment = new Comment
		{
			Id = Guid.NewGuid(),
			UserId = currentUser,
			PostId = request.Comment.PostId,
			Title = request.Comment.Title,
			Text = request.Comment.Text,
			ParentId = request.Comment.ParentId,
			IsActive = true
		};

		UnitOfWork.CommentRepository.AddComment(comment);

		Audit log = new()
		{
			Id = Guid.NewGuid(),
			EntityId = comment.Id,
			EntityTypeId = (int)eEntityType.Comment,
			ActionTypeId = (int)eActionType.Insert,
			IsSuccess = true,
			Time = DateTime.UtcNow,
			ExecutedBy = currentUser,
		};

		UnitOfWork.AuditRepository.Add(log);

		return await UnitOfWork.Complete()
			? Result.Success()
			: Result.Failure(Error.SaveChangesFailed);
	}
}