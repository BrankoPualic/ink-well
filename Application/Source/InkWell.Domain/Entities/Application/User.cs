using InkWell.Domain.Entities.Application_lu;
using InkWell.Domain.Entities.BaseEntities;

namespace InkWell.Domain.Entities.Application;

public class User : Entity
{
	public string FirstName { get; set; } = string.Empty;
	public string LastName { get; set; } = string.Empty;
	public string DisplayName { get; set; } = string.Empty;
	public string Email { get; set; } = string.Empty;
	public string Password { get; set; } = string.Empty;
	public string? ProfilePictureUrl { get; set; }
	public DateOnly DateOfBirth { get; set; }
	public virtual ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
}

public class UserRole
{
	public Guid UserId { get; set; }
	public int RoleId { get; set; }
	public virtual User User { get; set; }
	public virtual Role_lu Role { get; set; }
}