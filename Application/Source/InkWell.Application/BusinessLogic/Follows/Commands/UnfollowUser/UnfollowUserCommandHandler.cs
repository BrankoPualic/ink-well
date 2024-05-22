using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Identity.Extensions;
using InkWell.Application.Utilities;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;

namespace InkWell.Application.BusinessLogic.Follows.Commands.UnfollowUser;

internal class UnfollowUserCommandHandler : BaseHandler, ICommandHandler<UnfollowUserCommand>
{
	public UnfollowUserCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
	{
	}

	public async Task<Result> Handle(UnfollowUserCommand request, CancellationToken cancellationToken)
	{
		var followerId = UserContext.CurrentUserId;

		if (followerId.Equals(request.FollowingId))
		{
			return Result.Failure(Error.BadRequest);
		}

		var follow = await UnitOfWork.FollowRepository.GetFollowAsync(followerId, request.FollowingId, cancellationToken);

		if (follow is null)
		{
			return Result.Failure(Error<Follow>.NotFound);
		}

		follow.IsActive = false;

		if (await UnitOfWork.Complete())
		{
			return Result.Success();
		}

		return Result.Failure(Error.SaveChangesFailed);
	}
}