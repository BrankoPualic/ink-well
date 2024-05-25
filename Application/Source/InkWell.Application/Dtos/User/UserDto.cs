using InkWell.Application.Dtos._BaseDto;

namespace InkWell.Application.Dtos.User;

public class UserDto : BaseDto
{
	public Guid Id { get; set; }
	public string Username { get; set; } = string.Empty;
	public string? ProfilePictureUrl { get; set; }
	public int Followers { get; set; }
	public int Following { get; set; }
}