namespace InkWell.Domain.Entities.Application;

public class Upvote
{
	public Guid UserId { get; set; }
	public Guid CommentId { get; set; }
	public bool IsActive { get; set; }
	public DateTime Time { get; set; }
	public virtual User User { get; set; }
	public virtual Comment Comment { get; set; }
}