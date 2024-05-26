using InkWell.Domain.Entities.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InkWell.Persistence.Configurations.ApplicationConfigurations;

internal class LikeConfiguration : IEntityTypeConfiguration<Like>
{
	public void Configure(EntityTypeBuilder<Like> builder)
	{
		builder.HasKey(x => new { x.UserId, x.PostId });

		builder.Property(x => x.IsActive).HasDefaultValue(true);

		builder.HasOne(x => x.User)
			.WithMany(u => u.Likes)
			.HasForeignKey(x => x.UserId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(x => x.Post)
			.WithMany(p => p.Likes)
			.HasForeignKey(x => x.PostId)
			.OnDelete(DeleteBehavior.Restrict);
	}
}