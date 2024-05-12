using InkWell.Common;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace InkWell.Application.Identity.Utilities;

internal sealed class JwtUtility
{
	private readonly IConfiguration _configuration;

	public JwtUtility(IConfiguration configuration)
	{
		_configuration = configuration;
	}

	public string GenerateToken(Guid userId, string[] roles)
	{
		var tokenHandler = new JwtSecurityTokenHandler();

		var jwtSecrets = new
		{
			Key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!),
			Issuer = _configuration["Jwt:Issuer"],
			Audience = _configuration["Jwt:Audience"]
		};

		var claims = new List<Claim>
		{
			new(JwtRegisteredClaimNames.NameId, userId.ToString()),
			new(JwtRegisteredClaimNames.Iss, jwtSecrets.Issuer!)
		};

		claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

		var tokenDescriptor = new SecurityTokenDescriptor
		{
			Issuer = jwtSecrets.Issuer,
			Audience = jwtSecrets.Audience,
			Expires = DateTime.UtcNow.AddHours(Constants.TOKEN_EXPIRATION_TIME),
			SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(jwtSecrets.Key), SecurityAlgorithms.HmacSha512Signature),
			Claims = claims.ToDictionary(claim => claim.Type, claim => (object)claim.Value)
		};

		var token = tokenHandler.CreateToken(tokenDescriptor);

		return tokenHandler.WriteToken(token);
	}
}