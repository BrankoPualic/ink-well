using InkWell.Common.Abstractions;
using InkWell.Domain.Utilities.Storage;

namespace InkWell.Domain.Abstractions;

public interface ICloudinaryStorage
{
	Task<PhotoUploadResult> UploadPhotoAsync(IFile file);

	Task<PhotoDeletionResult> DeletePhotoAsync(string publicId);
}