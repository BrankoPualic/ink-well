namespace InkWell.Domain.Entities.BaseEntities;

public interface IAuditableEntity
{
	public DateTime CreatedAt { get; set; }
	public DateTime? ModifiedAt { get; set; }
	public Guid? ModifiedBy { get; set; }
	public DateTime? DeletedAt { get; set; }
	public Guid? DeletedBy { get; set; }
}