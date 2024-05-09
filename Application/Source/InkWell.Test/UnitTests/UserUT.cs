using InkWell.Application.Identity.Services;

namespace InkWell.Test.UnitTests;

public class UserUT
{
	[Test]
	public void VerifyPassword_Test()
	{
		string password = "Pa$$w0rd";

		string hashsedPassword = UserService.HashPassword(password);

		bool result = UserService.VerifyPassword(password, hashsedPassword);

		Assert.That(result, Is.True);
	}
}