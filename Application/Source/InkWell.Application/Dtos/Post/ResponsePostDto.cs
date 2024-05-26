using InkWell.Application.Dtos._BaseDto;
using InkWell.Application.Dtos.User;

namespace InkWell.Application.Dtos.Post;

public class ResponsePostDto : BaseDto
{
	public Guid Id { get; set; }
	public string Title { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public string Text { get; set; } = string.Empty;
	public int ViewCount { get; set; }
	public string PostImageUrl { get; set; } = string.Empty;
	public string Category { get; set; } = string.Empty;
	public DateTime CreatedAt { get; set; }
	public int Comments { get; set; }
	public int Likes { get; set; }
	public ProfileDto Author { get; set; }
}