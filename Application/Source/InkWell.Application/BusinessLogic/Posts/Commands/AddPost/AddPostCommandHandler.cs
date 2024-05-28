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

namespace InkWell.Application.BusinessLogic.Posts.Commands.AddPost;

internal class AddPostCommandHandler : BaseHandler<EntryPostDto>, ICommandHandler<AddPostCommand>
{
	private readonly ICloudinaryStorage _cloudinaryStorage;

	public AddPostCommandHandler(
		IUnitOfWork unitOfWork,
		IValidator<EntryPostDto> validator,
		ICloudinaryStorage cloudinaryStorage) : base(unitOfWork, validator)
	{
		_cloudinaryStorage = cloudinaryStorage;
	}

	public ICloudinaryStorage Cloudinary => _cloudinaryStorage;

	public async Task<Result> Handle(AddPostCommand request, CancellationToken cancellationToken)
	{
		var validationResult = await Validator.ValidateAsync(request.Post, cancellationToken);

		if (!validationResult.IsValid)
		{
			return ValidationError.FailureWithValidationResult(validationResult);
		}

		var currentUser = UserContext.CurrentUserId;

		var newPost = new Post
		{
			Id = Guid.NewGuid(),
			Title = request.Post.Title,
			Description = request.Post.Description,
			Text = request.Post.Text,
			ViewCount = 0,
			AuthorId = currentUser,
			CategoryId = request.Post.CategoryId
		};

		var file = new FormFileAdapter(request.Post.PostImage);

		try
		{
			var imageUploadResult = await Cloudinary.UploadPhotoAsync(file);

			newPost.PostImageUrl = imageUploadResult.Url;
			newPost.PublicId = imageUploadResult.PublicId;
		}
		catch (Exception ex)
		{
			return Result.Failure(Error.ServerError);
		}

		UnitOfWork.PostRepository.AddPost(newPost);

		Audit log = new()
		{
			Id = Guid.NewGuid(),
			EntityId = newPost.Id,
			EntityTypeId = (int)eEntityType.Post,
			ActionTypeId = (int)eActionType.Insert,
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