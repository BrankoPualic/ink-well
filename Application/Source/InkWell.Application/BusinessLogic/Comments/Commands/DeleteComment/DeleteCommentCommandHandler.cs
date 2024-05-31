using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Helpers;
using InkWell.Application.Identity.Extensions;
using InkWell.Application.Utilities;
using InkWell.Common.Enums;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;

namespace InkWell.Application.BusinessLogic.Comments.Commands.DeleteComment;

internal class DeleteCommentCommandHandler : BaseHandler, ICommandHandler<DeleteCommentCommand>
{
	public DeleteCommentCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
	{
	}

	public async Task<Result> Handle(DeleteCommentCommand request, CancellationToken cancellationToken)
	{
		var currentUser = UserContext.CurrentUserId;

		var comment = await UnitOfWork.CommentRepository.GetCommentAsync(request.CommentId, currentUser, cancellationToken);

		if (comment is null)
		{
			return Result.Failure(Error<Comment>.NotFound);
		}

		comment.IsActive = false;
		comment.DeletedAt = DateTime.UtcNow;
		comment.DeletedBy = currentUser;

		Audit log = new()
		{
			Id = Guid.NewGuid(),
			EntityId = comment.Id,
			EntityTypeId = (int)eEntityType.Comment,
			ActionTypeId = (int)eActionType.Delete,
			IsSuccess = true,
			Time = DateTime.UtcNow,
			ExecutedBy = currentUser,
		};

		UnitOfWork.AuditRepository.Add(log);

		if (comment.Replies.Count > 0)
		{
			CommandHelpers.DeactivateCommentReplies(comment.Replies, UnitOfWork);
		}

		return await UnitOfWork.Complete()
			? Result.Success()
			: Result.Failure(Error.SaveChangesFailed);
	}
}