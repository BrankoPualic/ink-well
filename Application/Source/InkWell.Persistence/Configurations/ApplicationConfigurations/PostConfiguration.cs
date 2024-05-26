using InkWell.Common;
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

		builder.HasOne(x => x.Author)
			.WithMany(u => u.Posts)
			.HasForeignKey(x => x.AuthorId)
			.OnDelete(DeleteBehavior.Restrict);

		builder.HasOne(x => x.Category)
			.WithMany(c => c.Posts)
			.HasForeignKey(x => x.CategoryId)
			.OnDelete(DeleteBehavior.Restrict);

		List<Post> posts = PostSeeds();

		builder.HasData(posts);
	}

	private static List<Post> PostSeeds()
	{
		var list = new List<Post>();

		var p1 = new Post
		{
			Id = Guid.NewGuid(),
			Title = "First Post",
			Description = "This is the first post created by seeds.",
			Text = "Hello from Admin.",
			ViewCount = 0,
			PostImageUrl = "",
			PublicId = "",
			AuthorId = Guid.Parse(Constants.SYSTEM_USER_ID),
			CategoryId = Guid.Parse(Constants.TRAVEL_CATEGORY_ID),
			CreatedAt = DateTime.UtcNow,
		};

		var p2 = new Post
		{
			Id = Guid.NewGuid(),
			Title = "Second Post",
			Description = "This is the second post created by seeds.",
			Text = "Hello from Admin.",
			ViewCount = 0,
			PostImageUrl = "",
			PublicId = "",
			AuthorId = Guid.Parse(Constants.SYSTEM_USER_ID),
			CategoryId = Guid.Parse(Constants.TRAVEL_CATEGORY_ID),
			CreatedAt = DateTime.UtcNow,
		};

		list.AddRange([p1, p2]);

		return list;
	}
}