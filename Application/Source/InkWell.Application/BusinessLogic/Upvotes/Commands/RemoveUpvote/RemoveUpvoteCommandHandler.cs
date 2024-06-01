using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Identity.Extensions;
using InkWell.Application.Utilities;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;

namespace InkWell.Application.BusinessLogic.Upvotes.Commands.RemoveUpvote;

internal class RemoveUpvoteCommandHandler : BaseHandler, ICommandHandler<RemoveUpvoteCommand>
{
	public RemoveUpvoteCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
	{
	}

	public async Task<Result> Handle(RemoveUpvoteCommand request, CancellationToken cancellationToken)
	{
		var currentUser = UserContext.CurrentUserId;

		var upvote = await UnitOfWork.UpvoteRepository.GetUpvoteAsync(currentUser, request.CommentId, cancellationToken);

		if (upvote is null)
		{
			return Result.Failure(Error<Upvote>.NotFound);
		}

		upvote.IsActive = false;

		return await UnitOfWork.Complete()
			? Result.Success()
			: Result.Failure(Error.SaveChangesFailed);
	}
}