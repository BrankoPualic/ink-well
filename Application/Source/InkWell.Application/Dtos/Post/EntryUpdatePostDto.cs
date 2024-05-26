using InkWell.Application.Dtos._BaseDto;
using Microsoft.AspNetCore.Http;

namespace InkWell.Application.Dtos.Post;

public class EntryUpdatePostDto : BaseDto
{
	public string? Title { get; set; }
	public string? Description { get; set; }
	public string? Text { get; set; }
	public IFormFile? PostImage { get; set; }
	public Guid? CategoryId { get; set; }
}