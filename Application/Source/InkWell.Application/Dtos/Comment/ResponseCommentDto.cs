using InkWell.Application.Dtos._BaseDto;
using InkWell.Application.Dtos.User;

namespace InkWell.Application.Dtos.Comment;

public class ResponseCommentDto : BaseDto
{
	public Guid Id { get; set; }
	public string? Title { get; set; }
	public string Text { get; set; } = string.Empty;
	public Guid? ParentId { get; set; }
	public DateTime CreatedAt { get; set; }
	public DateTime? ModifiedAt { get; set; }
	public int Upvotes { get; set; }
	public int Replies { get; set; }
	public ProfileDto User { get; set; }
	public IEnumerable<ResponseCommentDto> ReplyComments { get; set; } = new HashSet<ResponseCommentDto>();
}