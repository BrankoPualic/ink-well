namespace InkWell.Domain.Entities.BaseEntities;

public abstract class Entity : IBaseEntity, IAuditableEntity
{
	public Guid Id { get; set; }
	public bool IsActive { get; set; }
	public DateTime CreatedAt { get; set; }
	public DateTime? ModifiedAt { get; set; }
	public Guid? ModifiedBy { get; set; }
	public DateTime? DeletedAt { get; set; }
	public Guid? DeletedBy { get; set; }
}