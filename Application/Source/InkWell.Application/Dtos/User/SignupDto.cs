using InkWell.Application.Dtos._BaseDto;
using Microsoft.AspNetCore.Http;

namespace InkWell.Application.Dtos.User;

public class SignupDto : BaseDto
{
	public string Username { get; set; } = string.Empty;
	public string Email { get; set; } = string.Empty;
	public string FirstName { get; set; } = string.Empty;
	public string LastName { get; set; } = string.Empty;
	public string Password { get; set; } = string.Empty;
	public string ConfirmPassword { get; set; } = string.Empty;
	public IFormFile? ProfilePictureUrl { get; set; }
	public DateOnly DateOfBirth { get; set; }
}