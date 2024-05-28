using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Identity.Extensions;
using InkWell.Application.Utilities;
using InkWell.Common;
using InkWell.Common.Enums;
using InkWell.Domain.Abstractions;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;

namespace InkWell.Application.BusinessLogic.Posts.Commands.DeletePost;

internal class DeletePostCommandHandler : BaseHandler, ICommandHandler<DeletePostCommand>
{
	private readonly ICloudinaryStorage _cloudinaryStorage;

	public DeletePostCommandHandler(IUnitOfWork unitOfWork, ICloudinaryStorage cloudinaryStorage) : base(unitOfWork)
	{
		_cloudinaryStorage = cloudinaryStorage;
	}

	public ICloudinaryStorage Cloudinary => _cloudinaryStorage;

	public async Task<Result> Handle(DeletePostCommand request, CancellationToken cancellationToken)
	{
		var post = await UnitOfWork.PostRepository.GetPostByIdAsync(request.Id, cancellationToken);

		if (post is null)
		{
			return Result.Failure(Error<Post>.NotFound);
		}

		Guid currentUserId = UserContext.CurrentUserId;
		List<string> roles = UserContext.CurrentRoles;

		if (roles.Contains(eUserRole.Blogger.ToString())
			&& !currentUserId.Equals(post.AuthorId))
		{
			return Result.Failure(Error.BadRequest);
		}

		post.IsActive = false;
		post.DeletedBy = currentUserId;
		post.DeletedAt = DateTime.UtcNow;

		try
		{
			var deletionResult = await Cloudinary.DeletePhotoAsync(post.PublicId);

			post.PostImageUrl = "";
			post.PublicId = "";
		}
		catch (Exception ex)
		{
			Result.Failure(Error.SaveChangesFailed);
		}

		Audit log = new()
		{
			Id = Guid.NewGuid(),
			EntityId = post.Id,
			EntityTypeId = (int)eEntityType.Post,
			ActionTypeId = (int)eActionType.Delete,
			IsSuccess = true,
			Time = DateTime.UtcNow,
			ExecutedBy = currentUserId,
		};

		UnitOfWork.AuditRepository.Add(log);

		return await UnitOfWork.Complete()
			? Result.Success()
			: Result.Failure(Error.SaveChangesFailed);
	}
}