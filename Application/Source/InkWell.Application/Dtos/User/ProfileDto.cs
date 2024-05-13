namespace InkWell.Application.Dtos.User;

public class ProfileDto : UserDto
{
	public string FullName { get; set; } = string.Empty;
	public DateOnly DateOfBirth { get; set; }
}