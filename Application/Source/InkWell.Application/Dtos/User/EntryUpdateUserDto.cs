using InkWell.Application.Dtos._BaseDto;
using Microsoft.AspNetCore.Http;

namespace InkWell.Application.Dtos.User;

public class EntryUpdateUserDto : BaseDto
{
	public string FirstName { get; set; } = string.Empty;
	public string LastName { get; set; } = string.Empty;
	public DateOnly DateOfBirth { get; set; }
	public IFormFile? ProfilePicture { get; set; }
}