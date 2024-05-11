using FluentAssertions;
using InkWell.Application.Identity.Extensions;
using InkWell.Application.Identity.Middlewares;
using InkWell.Common;
using Microsoft.AspNetCore.Http;
using Moq;
using System.Security.Claims;

namespace InkWell.Test.Middlewares;

[TestFixture]
public class UserContextMiddlewareTests
{
	[Test]
	public async Task InvokeAsync_NoUserIdClaim_Should_SetCurrentUserToSystemUser()
	{
		var mockNext = new Mock<RequestDelegate>();
		var middleware = new UserContextMiddleware(mockNext.Object);

		var mockHttpContext = new DefaultHttpContext();
		var mockUser = new ClaimsPrincipal();

		mockHttpContext.User = mockUser;

		await middleware.InvokeAsync(mockHttpContext);

		UserContext.CurrentUserId.Should().Be(Guid.Parse(Constants.SYSTEM_USER_ID));
	}
}