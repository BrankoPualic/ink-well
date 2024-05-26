using InkWell.Domain.Entities.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InkWell.Persistence.Configurations.ApplicationConfigurations;

internal class UpvoteConfiguration : IEntityTypeConfiguration<Upvote>
{
	public void Configure(EntityTypeBuilder<Upvote> builder)
	{
		builder.HasKey(x => new { x.UserId, x.CommentId });

		builder.Property(x => x.IsActive).HasDefaultValue(true);

		builder.HasOne(x => x.User)
			.WithMany(u => u.Upvotes)
			.HasForeignKey(x => x.UserId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(x => x.Comment)
			.WithMany(c => c.Upvotes)
			.HasForeignKey(x => x.CommentId)
			.OnDelete(DeleteBehavior.Restrict);
	}
}