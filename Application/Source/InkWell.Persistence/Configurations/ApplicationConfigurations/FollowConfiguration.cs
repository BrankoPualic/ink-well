using InkWell.Domain.Entities.Application;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InkWell.Persistence.Configurations.ApplicationConfigurations;

internal class FollowConfiguration : IEntityTypeConfiguration<Follow>
{
	public void Configure(EntityTypeBuilder<Follow> builder)
	{
		builder.HasKey(x => new { x.FollowerId, x.FollowingId });

		builder.Property(x => x.IsActive)
			.HasDefaultValue(true);

		builder.HasOne(x => x.Follower)
			.WithMany(u => u.Following)
			.HasForeignKey(x => x.FollowerId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(x => x.Following)
			.WithMany(u => u.Followers)
			.HasForeignKey(x => x.FollowingId)
			.OnDelete(DeleteBehavior.Restrict);
	}
}