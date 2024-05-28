using FluentValidation;
using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos.Post;
using InkWell.Application.Identity.Extensions;
using InkWell.Application.Utilities;
using InkWell.Common.Enums;
using InkWell.Common.Storage;
using InkWell.Domain.Abstractions;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;

namespace InkWell.Application.BusinessLogic.Posts.Commands.UpdatePost;

internal class UpdatePostCommandHandler : BaseHandler<EntryUpdatePostDto>, ICommandHandler<UpdatePostCommand>
{
	private readonly ICloudinaryStorage _cloudinaryStorage;

	public UpdatePostCommandHandler(
		IUnitOfWork unitOfWork,
		IValidator<EntryUpdatePostDto> validator,
		ICloudinaryStorage cloudinaryStorage) : base(unitOfWork, validator)
	{
		_cloudinaryStorage = cloudinaryStorage;
	}

	public ICloudinaryStorage Cloudinary => _cloudinaryStorage;

	public async Task<Result> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
	{
		var validationResult = await Validator.ValidateAsync(request.Post, cancellationToken);

		if (!validationResult.IsValid)
		{
			return ValidationError.FailureWithValidationResult(validationResult);
		}

		if (request.Post.Title is null
			&& request.Post.Description is null
			&& request.Post.Text is null
			&& request.Post.PostImage is null
			&& request.Post.CategoryId is null)
		{
			return Result.Failure(Error.BadRequest);
		}

		var post = await UnitOfWork.PostRepository.GetPostByIdAsync(request.PostId, cancellationToken);

		if (post is null)
		{
			return Result.Failure(Error<Post>.NotFound);
		}

		if (request.Post.PostImage is not null)
		{
			var file = new FormFileAdapter(request.Post.PostImage);
			try
			{
				var imageUploadResult = await Cloudinary.UploadPhotoAsync(file);

				if (!post.PostImageUrl.Equals("")
					&& !post.PublicId.Equals(""))
				{
					var deletion = await Cloudinary.DeletePhotoAsync(post.PublicId);
				}

				post.PostImageUrl = imageUploadResult.Url;
				post.PublicId = imageUploadResult.PublicId;
			}
			catch (Exception ex)
			{
				return Result.Failure(Error.ServerError);
			}
		}

		post.Title = request.Post.Title ?? post.Title;
		post.Description = request.Post.Description ?? post.Description;
		post.Text = request.Post.Text ?? post.Text;
		post.CategoryId = request.Post.CategoryId ?? post.CategoryId;

		Audit log = new()
		{
			Id = Guid.NewGuid(),
			EntityId = UserContext.CurrentUserId,
			EntityTypeId = (int)eEntityType.Post,
			ActionTypeId = (int)eActionType.Update,
			IsSuccess = true,
			Time = DateTime.UtcNow,
			ExecutedBy = UserContext.CurrentUserId,
		};

		UnitOfWork.AuditRepository.Add(log);

		return await UnitOfWork.Complete()
			? Result.Success()
			: Result.Failure(Error.SaveChangesFailed);
	}
}