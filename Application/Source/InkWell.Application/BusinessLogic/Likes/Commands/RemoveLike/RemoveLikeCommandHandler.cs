using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Identity.Extensions;
using InkWell.Application.Utilities;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;

namespace InkWell.Application.BusinessLogic.Likes.Commands.RemoveLike;

internal class RemoveLikeCommandHandler : BaseHandler, ICommandHandler<RemoveLikeCommand>
{
	public RemoveLikeCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
	{
	}

	public async Task<Result> Handle(RemoveLikeCommand request, CancellationToken cancellationToken)
	{
		var userWhoIsRemovingLikeId = UserContext.CurrentUserId;

		var like = await UnitOfWork.LikeRepository.GetLikeAsync(userWhoIsRemovingLikeId, request.PostId, cancellationToken);

		if (like is null)
		{
			return Result.Failure(Error<Like>.NotFound);
		}

		like.IsActive = false;

		return await UnitOfWork.Complete()
			? Result.Success()
			: Result.Failure(Error.SaveChangesFailed);
	}
}