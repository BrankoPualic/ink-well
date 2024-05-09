using InkWell.Domain.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InkWell.Persistence.Configurations.BaseConfigurations;

internal abstract class BaseEntityConfiguration<T> : IEntityTypeConfiguration<T>
	where T : BaseEntity
{
	public virtual void Configure(EntityTypeBuilder<T> builder)
	{
		builder.HasKey(x => x.Id);

		builder.Property(x => x.IsActive)
			.HasDefaultValue(true);

		ConfigureEntity(builder);
	}

	protected abstract void ConfigureEntity(EntityTypeBuilder<T> builder);
}