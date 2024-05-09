using InkWell.Application.Identity.Extensions;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace InkWell.Application.Identity.Middlewares;

public class UserContextMiddleware
{
	private readonly RequestDelegate _next;

	public UserContextMiddleware(RequestDelegate next)
	{
		_next = next;
	}

	public async Task InvokeAsync(HttpContext context)
	{
		var userIdClaim = context.User.FindFirst(ClaimTypes.NameIdentifier).Value;

		UserContext.CurrentUserId = Guid.Parse(userIdClaim);

		await _next(context);
	}
}