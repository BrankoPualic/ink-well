namespace InkWell.Application.Identity.Services;

public static class UserService
{
	public static string HashPassword(string password)
	{
		return BCrypt.Net.BCrypt.HashPassword(password);
	}

	public static bool VerifyPassword(string password, string storedPassword)
	{
		return BCrypt.Net.BCrypt.Verify(password, storedPassword);
	}
}