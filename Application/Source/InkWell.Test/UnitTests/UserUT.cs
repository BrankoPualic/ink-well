using FluentAssertions;
using InkWell.Application.Identity.Services;

namespace InkWell.Test.UnitTests;

public class UserUT
{
	[Test]
	public void VerifyPassword()
	{
		string password = "Pa$$w0rd";

		string hashsedPassword = UserService.HashPassword(password);

		bool result = UserService.VerifyPassword(password, hashsedPassword);

		result.Should().BeTrue();
	}
}