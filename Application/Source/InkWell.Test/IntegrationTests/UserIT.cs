using FluentAssertions;
using InkWell.Application.Dtos.User;
using InkWell.Application.Utilities;
using InkWell.Persistence.Contexts;
using InkWell.Test.IntegrationTests.BaseFixture;
using Newtonsoft.Json;
using System.Net;

namespace InkWell.Test.IntegrationTests;

[TestFixture]
public class UserIT : TestFixture
{
	[Test]
	public async Task SignupController_Should_ReturnOK_WhenSuccessful_AndShould_Return403_WhenUserIs_YoungerThan10()
	{
		var client = Factory.CreateClient();

		var userData = new SignupDto
		{
			FirstName = "Test",
			LastName = "User",
			Username = "testuser1",
			Email = "test@test.test",
			Password = "Testing1@",
			ConfirmPassword = "Testing1@",
			DateOfBirth = DateOnly.FromDateTime(DateTime.Today.AddYears(-9))
		};

		var formData = CreateUserData(userData);

		var responseErr = await client.PostAsync("https://localhost:7219/api/auth/signup", formData);

		responseErr.StatusCode.Should().Be(HttpStatusCode.UnprocessableEntity);

		var resultErr = responseErr.Content.ReadAsStringAsync().Result;

		var resultJsonErr = JsonConvert.DeserializeObject<ValidationError>(resultErr);

		resultJsonErr.Should().NotBeNull();
		resultJsonErr.GetType().Should().Be(typeof(ValidationError));

		userData.DateOfBirth = DateOnly.FromDateTime(DateTime.Today.AddYears(-10));

		formData = CreateUserData(userData);

		var responseSuc = await client.PostAsync("https://localhost:7219/api/auth/signup", formData);

		var resultSuc = responseSuc.Content.ReadAsStringAsync().Result;
		responseSuc.StatusCode.Should().Be(HttpStatusCode.OK);

		var resultJsonSuc = JsonConvert.DeserializeObject<AuthResponseDto>(resultSuc);

		resultJsonSuc.Should().NotBeNull();
		resultJsonSuc.GetType().Should().Be(typeof(AuthResponseDto));
	}

	private MultipartFormDataContent CreateUserData(SignupDto userData)
	{
		return new MultipartFormDataContent
		{
			{ new StringContent(userData.FirstName), "FirstName" },
			{ new StringContent(userData.LastName), "LastName" },
			{ new StringContent(userData.Username), "Username" },
			{ new StringContent(userData.Email), "Email" },
			{ new StringContent(userData.Password), "Password" },
			{ new StringContent(userData.ConfirmPassword), "ConfirmPassword" },
			{ new StringContent(userData.DateOfBirth.ToString()), "DateOfBirth" }
		};
	}

	[OneTimeTearDown]
	public override void TearDown()
	{
		var dbContext = new InkWellContext();

		var userWithRoles = dbContext.Users
		.Where(u => u.Username.Contains("testuser1"))
		.Join(
			dbContext.UserRoles,
			user => user.Id,
			role => role.UserId,
			(user, role) => new { User = user, Role = role })
		.ToList();

		foreach (var item in userWithRoles)
		{
			dbContext.Remove(item.Role);
		}

		var audit = dbContext.Audits
			.Where(x => x.ExecutedBy.Equals(userWithRoles.First().User.Id))
			.FirstOrDefault();

		dbContext.Remove(audit);

		if (userWithRoles.Count != 0)
		{
			dbContext.Remove(userWithRoles.First().User);
		}

		dbContext.SaveChanges();

		base.TearDown();
	}
}