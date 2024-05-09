namespace InkWell.Domain.Entities.BaseEntities;

public abstract class Entity : BaseEntity, IAuditableEntity
{
	public DateTime CreatedAt { get; set; }
	public DateTime? ModifiedAt { get; set; }
	public Guid? ModifiedBy { get; set; }
	public DateTime? DeletedAt { get; set; }
	public Guid? DeletedBy { get; set; }
}