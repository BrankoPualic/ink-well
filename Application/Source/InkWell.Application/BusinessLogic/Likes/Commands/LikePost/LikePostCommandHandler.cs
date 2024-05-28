using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Identity.Extensions;
using InkWell.Application.Utilities;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;

namespace InkWell.Application.BusinessLogic.Likes.Commands.LikePost;

internal class LikePostCommandHandler : BaseHandler, ICommandHandler<LikePostCommand>
{
	public LikePostCommandHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
	{
	}

	public async Task<Result> Handle(LikePostCommand request, CancellationToken cancellationToken)
	{
		var userWhoLikedId = UserContext.CurrentUserId;

		var userWhoLiked = await UnitOfWork.UserRepository.GetUserByIdAsync(userWhoLikedId, cancellationToken);
		var post = await UnitOfWork.PostRepository.GetPostByIdAsync(request.Like.PostId, cancellationToken);

		if (userWhoLiked is null)
		{
			return Result.Failure(Error.BadRequest);
		}

		if (post is null)
		{
			return Result.Failure(Error<Post>.NotFound);
		}

		var existingLike = await UnitOfWork.LikeRepository.GetLikeAsync(userWhoLikedId, request.Like.PostId, cancellationToken);

		if (existingLike is not null)
		{
			existingLike.IsActive = true;
		}
		else
		{
			var like = new Like
			{
				UserId = userWhoLikedId,
				PostId = request.Like.PostId,
				IsActive = true,
				Time = DateTime.UtcNow
			};

			UnitOfWork.LikeRepository.Like(like);
		}

		return await UnitOfWork.Complete()
			? Result.Success()
			: Result.Failure(Error.SaveChangesFailed);
	}
}