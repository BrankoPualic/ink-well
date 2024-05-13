using InkWell.Common.Enums;
using InkWell.Domain.Entities.Application_lu;
using InkWell.Persistence.Configurations.BaseConfigurations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InkWell.Persistence.Configurations.Application_luConfiguration;

internal class ActionType_luConfiguration : Entity_luConfiguration<ActionType_lu>
{
	protected override void ConfigureEntity(EntityTypeBuilder<ActionType_lu> builder)
	{
		builder.HasData(
			new ActionType_lu { Id = (int)eActionType.Insert, Name = eActionType.Insert.ToString() },
			new ActionType_lu { Id = (int)eActionType.Update, Name = eActionType.Update.ToString() },
			new ActionType_lu { Id = (int)eActionType.Delete, Name = eActionType.Delete.ToString() });
	}
}