using InkWell.Domain.Entities.Application;
using InkWell.Persistence.Configurations.BaseConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InkWell.Persistence.Configurations.ApplicationConfigurations;

internal class CategoryConfiguration : BaseEntityConfiguration<Category>
{
	protected override void ConfigureEntity(EntityTypeBuilder<Category> builder)
	{
		builder.Property(x => x.Name)
			.IsRequired()
			.HasMaxLength(50);

		builder.HasIndex(x => x.Name)
			.IsUnique();

		builder.HasMany(x => x.Posts)
			.WithOne(p => p.Category)
			.HasForeignKey(p => p.CategoryId)
			.OnDelete(DeleteBehavior.Restrict);
	}
}