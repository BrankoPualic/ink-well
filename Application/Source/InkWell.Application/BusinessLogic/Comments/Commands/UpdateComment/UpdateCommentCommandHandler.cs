using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Identity.Extensions;
using InkWell.Application.Utilities;
using InkWell.Common.Enums;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;

namespace InkWell.Application.BusinessLogic.Comments.Commands.UpdateComment;

internal class UpdateCommentCommandHandler : BaseHandler, ICommandHandler<UpdateCommentCommand>
{
	public UpdateCommentCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
	{
	}

	public async Task<Result> Handle(UpdateCommentCommand request, CancellationToken cancellationToken)
	{
		if (request.Comment is null
			|| (request.Comment.Title is null
			&& request.Comment.Text is null))
		{
			return Result.Failure(Error.BadRequest);
		}

		var comment = await UnitOfWork.CommentRepository.GetCommentByIdAsync(request.CommentId, cancellationToken);

		if (comment is null)
		{
			return Result.Failure(Error<Comment>.NotFound);
		}

		var currentUser = UserContext.CurrentUserId;

		if (!currentUser.Equals(comment.UserId))
		{
			return Result.Failure(Error.BadRequest);
		}

		comment.Text = request.Comment.Text ?? comment.Text;
		comment.Title = request.Comment.Title ?? comment.Title;

		Audit log = new()
		{
			Id = Guid.NewGuid(),
			EntityId = comment.Id,
			EntityTypeId = (int)eEntityType.Comment,
			ActionTypeId = (int)eActionType.Update,
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