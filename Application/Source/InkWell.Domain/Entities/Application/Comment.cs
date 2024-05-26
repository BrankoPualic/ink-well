using InkWell.Domain.Entities.BaseEntities;

namespace InkWell.Domain.Entities.Application;

public class Comment : Entity
{
	public Guid UserId { get; set; }
	public Guid PostId { get; set; }
	public string? Title { get; set; }
	public string Text { get; set; } = string.Empty;
	public Guid? ParentId { get; set; }

	public virtual Comment Parent { get; set; }
	public virtual User User { get; set; }
	public virtual Post Post { get; set; }
	public virtual ICollection<Comment> Replies { get; set; } = new HashSet<Comment>();
	public virtual ICollection<Upvote> Upvotes { get; set; } = new HashSet<Upvote>();
}