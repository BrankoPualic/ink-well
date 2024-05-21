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
using InkWell.Infrastructure.Logger;
using InkWell.Application.Identity.Abstractions;
using InkWell.Application.Identity.Services;
using InkWell.Common;
using InkWell.Common.Enums;
using InkWell.Infrastructure.Helpers;
using InkWell.Infrastructure.Storage;
using InkWell.Domain.Abstractions;

namespace InkWell.DependencyInjection;

public static class Extensions
{
	public static IServiceCollection AllApplicationServices(this IServiceCollection services, IConfiguration configuration)
	{
		PersistenceServices(services);
		ApplicationServices(services);
		IdentityServices(services, configuration);
		InfrastructureServices(services, configuration);

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

		services.AddAuthorizationBuilder()
			.AddPolicy(Constants.ADMINISTRATOR, policy => policy.RequireRole(
				eUserRole.Administrator.ToString()
				))
			.AddPolicy(Constants.ADMINISTRATOR_USERADMIN, policy => policy.RequireRole(
				eUserRole.Administrator.ToString(),
				eUserRole.UserAdmin.ToString()
				))
			.AddPolicy(Constants.ADMINISTRATOR_USERADMIN_MODERATOR, policy => policy.RequireRole(
				eUserRole.Administrator.ToString(),
				eUserRole.UserAdmin.ToString(),
				eUserRole.Moderator.ToString()
				))
			.AddPolicy(Constants.BLOGGER, policy => policy.RequireRole(
				eUserRole.Blogger.ToString()
				))
			.AddPolicy(Constants.MEMBER, policy => policy.RequireRole(
				eUserRole.Member.ToString()
				));

		services.AddScoped<IJwtService, AuthenticationService>();

		return services;
	}

	private static IServiceCollection PersistenceServices(IServiceCollection services)
	{
		services.AddDbContext<InkWellContext>(opt => opt.UseSqlServer(
			"Data Source=localhost;Initial Catalog=InkWell;TrustServerCertificate=true;Integrated security = true"));

		services.AddScoped<IUnitOfWork, UnitOfWork>();

		return services;
	}

	private static IServiceCollection InfrastructureServices(IServiceCollection services, IConfiguration configuration)
	{
		services.AddTransient<IExceptionLogger, DbExceptionLogger>();
		services.Configure<CloudinarySettings>(configuration.GetSection("CloudinarySettings"));
		services.AddScoped<ICloudinaryStorage, CloudinaryStorage>();

		return services;
	}
}