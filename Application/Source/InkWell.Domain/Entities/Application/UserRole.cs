using InkWell.Domain.Entities.Application_lu;

namespace InkWell.Domain.Entities.Application;

public class UserRole
{
	public Guid UserId { get; set; }
	public int RoleId { get; set; }
	public bool IsActive { get; set; }
	public virtual User User { get; set; }
	public virtual Role_lu Role { get; set; }
}