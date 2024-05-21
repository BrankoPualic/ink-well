namespace InkWell.Common.Abstractions;

public interface IFile
{
	string FileName { get; }
	long Length { get; }

	Stream OpenReadStream();
}