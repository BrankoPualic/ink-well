using FluentValidation;
using InkWell.Persistence.Contexts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.Extensions.Configuration;
using InkWell.Domain.Repositories;
using InkWell.Persistence.Repositories;

namespace InkWell.DependencyInjection;

public static class Extensions
{
	public static IServiceCollection AllApplicationServices(this IServiceCollection services, IConfiguration configuration)
	{
		PersistenceServices(services);
		ApplicationServices(services);
		IdentityServices(services, configuration);

		return services;
	}

	private static IServiceCollection ApplicationServices(IServiceCollection services)
	{
		var assembly = typeof(Application.Abstractions.Messaging.BaseHandler).Assembly;

		services.AddMediatR(config => config.RegisterServicesFromAssembly(assembly));
		services.AddValidatorsFromAssembly(assembly);
		services.AddAutoMapper(assembly);

		return services;
	}

	private static IServiceCollection IdentityServices(IServiceCollection services, IConfiguration configuration)
	{
		services.AddAuthentication(options =>
		{
			options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
			options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
		}).AddJwtBearer(options =>
		{
			options.TokenValidationParameters = new TokenValidationParameters
			{
				ValidateIssuer = true,
				ValidateAudience = true,
				ValidateLifetime = true,
				ValidateIssuerSigningKey = true,
				ValidIssuer = configuration["Jwt:Issuer"],
				ValidAudience = configuration["Jwt:Audience"],
				IssuerSigningKey = new SymmetricSecurityKey
				(Encoding.UTF8.GetBytes(configuration["Jwt:Key"]!)),
				ClockSkew = TimeSpan.Zero
			};
		});

		return services;
	}

	private static IServiceCollection PersistenceServices(IServiceCollection services)
	{
		services.AddDbContext<InkWellContext>(opt => opt.UseSqlServer(
			"Data Source=localhost;Initial Catalog=InkWell;TrustServerCertificate=true;Integrated security = true"));

		services.AddScoped<IUnitOfWork, UnitOfWork>();

		return services;
	}
}