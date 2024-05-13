using InkWell.Common.Enums;
using InkWell.Domain.Entities.Application_lu;
using InkWell.Persistence.Configurations.BaseConfigurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InkWell.Persistence.Configurations.Application_luConfiguration;

internal class EntityType_luConfiguration : Entity_luConfiguration<EntityType_lu>
{
	protected override void ConfigureEntity(EntityTypeBuilder<EntityType_lu> builder)
	{
		builder.HasData(
			new EntityType_lu { Id = (int)eEntityType.User, Name = eEntityType.User.ToString() },
			new EntityType_lu { Id = (int)eEntityType.Post, Name = eEntityType.Post.ToString() },
			new EntityType_lu { Id = (int)eEntityType.Comment, Name = eEntityType.Comment.ToString() });
	}
}