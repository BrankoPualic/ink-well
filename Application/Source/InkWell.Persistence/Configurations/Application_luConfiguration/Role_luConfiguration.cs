using InkWell.Common.Enums;
using InkWell.Domain.Entities.Application_lu;
using InkWell.Persistence.Configurations.BaseConfigurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InkWell.Persistence.Configurations.Application_luConfiguration;

internal class Role_luConfiguration : Entity_luConfiguration<Role_lu>
{
	protected override void ConfigureEntity(EntityTypeBuilder<Role_lu> builder)
	{
		builder.HasData(
			new Role_lu { Id = (int)eUserRole.Member, Name = eUserRole.Member.ToString() },
			new Role_lu { Id = (int)eUserRole.Moderator, Name = eUserRole.Moderator.ToString() },
			new Role_lu { Id = (int)eUserRole.Administrator, Name = eUserRole.Administrator.ToString() },
			new Role_lu { Id = (int)eUserRole.UserAdmin, Name = eUserRole.UserAdmin.ToString() },
			new Role_lu { Id = (int)eUserRole.Blogger, Name = eUserRole.Blogger.ToString() });
	}
}