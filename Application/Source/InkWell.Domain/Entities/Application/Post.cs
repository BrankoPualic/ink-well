using InkWell.Domain.Entities.BaseEntities;

namespace InkWell.Domain.Entities.Application;

public class Post : Entity
{
	public string Title { get; set; } = string.Empty;
	public string Description { get; set; } = string.Empty;
	public string Text { get; set; } = string.Empty;
	public int ViewCount { get; set; }
	public string PostImageUrl { get; set; } = string.Empty;
	public string PublicId { get; set; } = string.Empty;
	public Guid AuthorId { get; set; }
	public Guid CategoryId { get; set; }
	public virtual Category Category { get; set; }
	public virtual User Author { get; set; }
	public virtual ICollection<Comment> Comments { get; set; } = new HashSet<Comment>();
	public virtual ICollection<Like> Likes { get; set; } = new HashSet<Like>();
}