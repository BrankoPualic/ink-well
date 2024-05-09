using InkWell.Domain.Entities.Application;
using InkWell.Persistence.Configurations.BaseConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InkWell.Persistence.Configurations.ApplicationConfigurations;

internal class PostConfiguration : BaseEntityConfiguration<Post>
{
	protected override void ConfigureEntity(EntityTypeBuilder<Post> builder)
	{
		builder.Property(x => x.Title)
			.IsRequired()
			.HasMaxLength(50);

		builder.Property(x => x.Description)
			.IsRequired()
			.HasMaxLength(255);

		builder.Property(x => x.Text)
			.IsRequired();

		builder.HasOne(x => x.User)
			.WithMany(u => u.Posts)
			.HasForeignKey(x => x.AuthorId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(x => x.Category)
			.WithMany(c => c.Posts)
			.HasForeignKey(x => x.CategoryId)
			.OnDelete(DeleteBehavior.Restrict);
	}
}