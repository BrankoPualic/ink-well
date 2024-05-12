using InkWell.Application.Identity.Abstractions;
using InkWell.Application.Identity.Utilities;
using Microsoft.Extensions.Configuration;

namespace InkWell.Application.Identity.Services;

public class AuthenticationService : IJwtService
{
	private readonly JwtUtility _jwtUtility;

	public AuthenticationService(IConfiguration configuration)
	{
		_jwtUtility = new JwtUtility(configuration);
	}

	public string GenerateJwtToken(Guid userId, string[] roles)
	{
		return _jwtUtility.GenerateToken(userId, roles);
	}
}
