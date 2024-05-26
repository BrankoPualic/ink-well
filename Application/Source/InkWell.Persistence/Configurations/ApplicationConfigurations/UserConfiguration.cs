using InkWell.Application.Identity.Services;
using InkWell.Common;
using InkWell.Domain.Entities.Application;
using InkWell.Persistence.Configurations.BaseConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InkWell.Persistence.Configurations.ApplicationConfigurations;

internal class UserConfiguration : BaseEntityConfiguration<User>
{
	protected override void ConfigureEntity(EntityTypeBuilder<User> builder)
	{
		builder.Property(x => x.FirstName)
			.IsRequired()
			.HasMaxLength(20);

		builder.Property(x => x.LastName)
			.IsRequired()
			.HasMaxLength(50);

		builder.Property(x => x.FullName)
			.HasMaxLength(70)
			.HasComputedColumnSql("[FirstName] + ' ' + [LastName]");

		builder.Property(x => x.Username)
			.IsRequired()
			.HasMaxLength(20);
		builder.HasIndex(x => x.Username)
			.IsUnique();

		builder.Property(x => x.Email)
			.IsRequired()
			.HasMaxLength(60);
		builder.HasIndex(x => x.Email)
			.IsUnique();

		builder.HasIndex(x => new { x.FullName, x.Username, x.Email })
			.IncludeProperties(x => new { x.DateOfBirth });

		var users = UserSeeds();

		builder.HasData(users);
	}

	private static List<User> UserSeeds()
	{
		var list = new List<User>();

		var administrator = new User
		{
			Id = Guid.Parse(Constants.SYSTEM_USER_ID),
			Username = "system-admin1",
			Email = "sysadmin@inkwell.test",
			Password = UserService.HashPassword("SySadmin1@"),
			FirstName = "Branko",
			LastName = "Pualic-Radujko",
			DateOfBirth = new DateOnly(2002, 10, 10),
			CreatedAt = DateTime.UtcNow
		};

		var useradmin = new User
		{
			Id = Guid.Parse(Constants.SYSTEM_USERADMIN_ID),
			Username = "system-useradmin1",
			Email = "sysuseradmin@inkwell.test",
			Password = UserService.HashPassword("SySuseradmin1@"),
			FirstName = "Branko",
			LastName = "Pualic-Radujko",
			DateOfBirth = new DateOnly(2002, 10, 10),
			CreatedAt = DateTime.UtcNow
		};

		var moderator = new User
		{
			Id = Guid.Parse(Constants.SYSTEM_MODERATOR_ID),
			Username = "system-moderator1",
			Email = "sysmoderator@inkwell.test",
			Password = UserService.HashPassword("SySmoderator1@"),
			FirstName = "Branko",
			LastName = "Pualic-Radujko",
			DateOfBirth = new DateOnly(2002, 10, 10),
			CreatedAt = DateTime.UtcNow
		};

		var blogger = new User
		{
			Id = Guid.Parse(Constants.SYSTEM_BLOGGER_ID),
			Username = "system-blogger1",
			Email = "sysblogger@inkwell.test",
			Password = UserService.HashPassword("SySblogger1@"),
			FirstName = "Branko",
			LastName = "Pualic-Radujko",
			DateOfBirth = new DateOnly(2002, 10, 10),
			CreatedAt = DateTime.UtcNow
		};

		list.AddRange([administrator, useradmin, moderator, blogger]);

		return list;
	}
}