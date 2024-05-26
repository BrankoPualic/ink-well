using InkWell.Application.Dtos._BaseDto;
using Microsoft.AspNetCore.Http;

namespace InkWell.Application.Dtos.Post;

public class EntryPostDto : BaseDto
{
	public string Title { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public string Text { get; set; } = string.Empty;
	public IFormFile PostImage { get; set; }
	public Guid CategoryId { get; set; }
}