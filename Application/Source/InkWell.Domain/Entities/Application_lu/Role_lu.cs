using InkWell.Domain.Entities.Application;
using InkWell.Domain.Entities.BaseEntities;

namespace InkWell.Domain.Entities.Application_lu;

public class Role_lu : Entity_lu
{
	public virtual ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
}