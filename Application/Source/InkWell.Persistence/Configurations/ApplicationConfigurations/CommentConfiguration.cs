using InkWell.Domain.Entities.Application;
using InkWell.Persistence.Configurations.BaseConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace InkWell.Persistence.Configurations.ApplicationConfigurations;

internal class CommentConfiguration : BaseEntityConfiguration<Comment>
{
	protected override void ConfigureEntity(EntityTypeBuilder<Comment> builder)
	{
		builder.Property(x => x.Title)
			.HasMaxLength(30);

		builder.Property(x => x.Text)
			.IsRequired();

		builder.HasOne(x => x.Parent)
			.WithMany(x => x.Replies)
			.HasForeignKey(x => x.ParentId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(x => x.User)
			.WithMany(u => u.Comments)
			.HasForeignKey(x => x.UserId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(x => x.Post)
			.WithMany(p => p.Comments)
			.HasForeignKey(x => x.PostId)
			.OnDelete(DeleteBehavior.Restrict);
	}
}