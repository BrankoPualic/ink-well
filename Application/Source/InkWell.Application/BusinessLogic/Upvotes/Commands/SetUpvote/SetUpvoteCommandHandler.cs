using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Identity.Extensions;
using InkWell.Application.Utilities;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;

namespace InkWell.Application.BusinessLogic.Upvotes.Commands.SetUpvote;

internal class SetUpvoteCommandHandler : BaseHandler, ICommandHandler<SetUpvoteCommand>
{
	public SetUpvoteCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
	{
	}

	public async Task<Result> Handle(SetUpvoteCommand request, CancellationToken cancellationToken)
	{
		var comment = await UnitOfWork.CommentRepository.GetCommentByIdAsync(request.Upvote.CommentId, cancellationToken);

		if (comment is null)
		{
			return Result.Failure(Error<Comment>.NotFound);
		}

		var currentUser = UserContext.CurrentUserId;

		var existingUpvote = await UnitOfWork.UpvoteRepository.GetUpvoteAsync(currentUser, comment.Id, cancellationToken);

		if (existingUpvote is not null)
		{
			existingUpvote.IsActive = true;
		}
		else
		{
			var upvote = new Upvote
			{
				CommentId = comment.Id,
				UserId = UserContext.CurrentUserId,
				IsActive = true,
				Time = DateTime.UtcNow,
			};
			UnitOfWork.UpvoteRepository.Upvote(upvote);
		}

		return await UnitOfWork.Complete()
			? Result.Success()
			: Result.Failure(Error.SaveChangesFailed);
	}
}