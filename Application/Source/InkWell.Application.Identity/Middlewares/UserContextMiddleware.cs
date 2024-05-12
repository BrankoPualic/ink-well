using InkWell.Application.Identity.Extensions;
using InkWell.Common;
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
		try
		{
			string userIdClaim;
			if (context.User.FindFirstValue(ClaimTypes.NameIdentifier) is null)
			{
				userIdClaim = Constants.SYSTEM_USER_ID;
			}
			else
			{
				userIdClaim = context.User.FindFirst(ClaimTypes.NameIdentifier).Value;
			}

			UserContext.CurrentUserId = Guid.Parse(userIdClaim);

			await _next(context);
		}
		catch (Exception ex)
		{
			throw new Exception(ex.Message);
		}
	}
}