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

		builder.HasData(
			new UserRole
			{
				UserId = Guid.Parse(Constants.SYSTEM_USER_ID),
				RoleId = (byte)eUserRole.Administrator,
				IsActive = true
			});
	}
}