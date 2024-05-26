using InkWell.Common;
using InkWell.Common.Enums;
using InkWell.Domain.Entities.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InkWell.Persistence.Configurations.ApplicationConfigurations;

internal class UserRoleConfiguration : IEntityTypeConfiguration<UserRole>
{
	public void Configure(EntityTypeBuilder<UserRole> builder)
	{
		builder.HasKey(x => new { x.UserId, x.RoleId });

		builder.Property(x => x.IsActive)
			.HasDefaultValue(true);

		builder.HasOne(x => x.Role)
			.WithMany(r => r.UserRoles)
			.HasForeignKey(x => x.RoleId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(x => x.User)
			.WithMany(u => u.UserRoles)
			.HasForeignKey(x => x.UserId)
			.OnDelete(DeleteBehavior.Restrict);

		var userroles = UserRoleSeeds();
		builder.HasData(userroles);
	}

	private static List<UserRole> UserRoleSeeds()
	{
		var list = new List<UserRole>();

		var administrator = new UserRole
		{
			UserId = Guid.Parse(Constants.SYSTEM_USER_ID),
			RoleId = (int)eUserRole.Administrator,
			IsActive = true
		};

		var useradmin = new UserRole
		{
			UserId = Guid.Parse(Constants.SYSTEM_USERADMIN_ID),
			RoleId = (int)eUserRole.UserAdmin,
			IsActive = true
		};

		var moderator = new UserRole
		{
			UserId = Guid.Parse(Constants.SYSTEM_MODERATOR_ID),
			RoleId = (int)eUserRole.Moderator,
			IsActive = true
		};

		var blogger = new UserRole
		{
			UserId = Guid.Parse(Constants.SYSTEM_BLOGGER_ID),
			RoleId = (int)eUserRole.Blogger,
			IsActive = true
		};

		list.AddRange([administrator, useradmin, moderator, blogger]);

		return list;
	}
}