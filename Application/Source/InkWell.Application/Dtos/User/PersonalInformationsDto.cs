namespace InkWell.Application.Dtos.User;

public class PersonalInformationsDto : ProfileDto
{
	public string Email { get; set; } = string.Empty;
	public List<string> Roles { get; set; } = new List<string>();
	public bool IsActive { get; set; }
	public DateTime CreatedAt { get; set; }
	public DateTime? ModifiedAt { get; set; }
	public Guid? ModifiedBy { get; set; }
	public DateTime? DeletedAt { get; set; }
	public Guid? DeletedBy { get; set; }
}