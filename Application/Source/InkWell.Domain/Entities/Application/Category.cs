using InkWell.Domain.Entities.BaseEntities;

namespace InkWell.Domain.Entities.Application;

public class Category : Entity
{
	public string Name { get; set; } = string.Empty;
	public Guid? ParentId { get; set; }
	public virtual ICollection<Category> Children { get; set; } = new HashSet<Category>();
	public virtual Category Parent { get; set; }
	public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();
}