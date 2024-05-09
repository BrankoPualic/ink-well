namespace InkWell.Domain.Entities.BaseEntities;

public interface IBaseEntity
{
	Guid Id { get; set; }
	bool IsActive { get; set; }
}
