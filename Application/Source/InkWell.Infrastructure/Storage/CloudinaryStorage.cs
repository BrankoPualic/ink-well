using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using InkWell.Common.Abstractions;
using InkWell.Domain.Abstractions;
using InkWell.Domain.Utilities.Storage;
using InkWell.Infrastructure.Helpers;
using Microsoft.Extensions.Options;

namespace InkWell.Infrastructure.Storage;

public class CloudinaryStorage : ICloudinaryStorage
{
	private readonly Cloudinary _cloudinary;

	public CloudinaryStorage(IOptions<CloudinarySettings> configuration)
	{
		Account acc = new
		(
			configuration.Value.CloudName,
			configuration.Value.ApiKey,
			configuration.Value.ApiSecret
		);

		_cloudinary = new Cloudinary(acc);
	}

	public Cloudinary Cloudinary => _cloudinary;

	public async Task<PhotoUploadResult> UploadPhotoAsync(IFile file)
	{
		await using var stream = file.OpenReadStream();
		var uploadParams = new ImageUploadParams
		{
			File = new FileDescription(file.FileName, stream),
			Transformation = new Transformation().AspectRatio(1.77).Crop("fill"),
			Folder = "ink-well-asp-net8"
		};

		var uploadResult = await Cloudinary.UploadAsync(uploadParams);

		return new PhotoUploadResult
		{
			Url = uploadResult.SecureUrl.ToString(),
			PublicId = uploadResult.PublicId,
		};
	}

	public async Task<PhotoDeletionResult> DeletePhotoAsync(string publicId)
	{
		var deletionParams = new DeletionParams(publicId);
		var deletionResult = await Cloudinary.DestroyAsync(deletionParams);

		return new PhotoDeletionResult
		{
			Result = deletionResult.Result
		};
	}
}