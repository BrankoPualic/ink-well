using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Identity.Extensions;
using InkWell.Application.Utilities;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;

namespace InkWell.Application.BusinessLogic.Follows.Commands.FollowUser;

internal class FollowUserCommandHandler : BaseHandler, ICommandHandler<FollowUserCommand>
{
	public FollowUserCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
	{
	}

	public async Task<Result> Handle(FollowUserCommand request, CancellationToken cancellationToken)
	{
		var followerId = UserContext.CurrentUserId;

		if (followerId.Equals(request.Follow.FollowingId))
		{
			return Result.Failure(Error.BadRequest);
		}

		var followingUser = await UnitOfWork.UserRepository.GetUserByIdAsync(request.Follow.FollowingId, cancellationToken);
		var follower = await UnitOfWork.UserRepository.GetUserByIdAsync(followerId, cancellationToken);

		if (followingUser is null
			|| follower is null)
		{
			return Result.Failure(Error<User>.NotFound);
		}

		var existingFollow = await UnitOfWork.FollowRepository.GetFollowAsync(followerId, followingUser.Id, cancellationToken);

		if (existingFollow is not null)
		{
			existingFollow.IsActive = true;
		}
		else
		{
			var follow = new Follow
			{
				FollowerId = followerId,
				FollowingId = followingUser.Id,
				IsActive = true,
				FollowedAt = DateTime.UtcNow,
			};

			UnitOfWork.FollowRepository.Follow(follow);
		}

		if (await UnitOfWork.Complete())
		{
			return Result.Success();
		}

		return Result.Failure(Error.SaveChangesFailed);
	}
}