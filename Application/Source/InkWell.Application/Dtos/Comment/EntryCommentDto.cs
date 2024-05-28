using InkWell.Application.Dtos._BaseDto;

namespace InkWell.Application.Dtos.Comment;

public class EntryCommentDto : BaseDto
{
	public Guid PostId { get; set; }
	public string? Title { get; set; }
	public string Text { get; set; } = string.Empty;
	public Guid? ParentId { get; set; }
}