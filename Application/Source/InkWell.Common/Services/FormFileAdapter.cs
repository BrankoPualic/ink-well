using InkWell.Common.Abstractions;
using Microsoft.AspNetCore.Http;

namespace InkWell.Common.Storage;

public class FormFileAdapter : IFile
{
	private readonly IFormFile _formFile;

	public FormFileAdapter(IFormFile formFile)
	{
		_formFile = formFile;
	}

	public string FileName => _formFile.FileName;

	public long Length => _formFile.Length;

	public Stream OpenReadStream()
	{
		return _formFile.OpenReadStream();
	}
}