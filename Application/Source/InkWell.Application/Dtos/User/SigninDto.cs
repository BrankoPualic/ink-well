using InkWell.Application.Dtos._BaseDto;

namespace InkWell.Application.Dtos.User;

public class SigninDto : BaseDto
{
	public string Email { get; set; } = string.Empty;
	public string Password { get; set; } = string.Empty;
}