using InkWell.Domain.Entities.BaseEntities;

namespace InkWell.Domain.Entities.Application;

public class User : Entity
{
	public string Username { get; set; } = string.Empty;
	public string Email { get; set; } = string.Empty;
	public string Password { get; set; } = string.Empty;
	public string FirstName { get; set; } = string.Empty;
	public string LastName { get; set; } = string.Empty;
	public string FullName { get; set; } = string.Empty;
	public string? ProfilePictureUrl { get; set; }
	public DateOnly DateOfBirth { get; set; }
	public virtual ICollection<UserRole> UserRoles { get; set; } = new HashSet<UserRole>();
	public virtual ICollection<Post> Posts { get; set; } = new HashSet<Post>();
	public virtual ICollection<SigninLog> Signins { get; set; }
}