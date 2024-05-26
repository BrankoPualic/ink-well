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

		List<Category> categories = CategorySeeds();

		builder.HasData(categories);
	}

	private static List<Category> CategorySeeds()
	{
		var list = new List<Category>();

		var c1 = new Category
		{
			Id = Guid.NewGuid(),
			Name = "Travel",
			ParentId = null,
			IsActive = true,
			CreatedAt = DateTime.UtcNow,
		};

		var c2 = new Category
		{
			Id = Guid.NewGuid(),
			Name = "Sport",
			ParentId = null,
			IsActive = true,
			CreatedAt = DateTime.UtcNow,
		};

		var c3 = new Category
		{
			Id = Guid.NewGuid(),
			Name = "Basketball",
			ParentId = c2.Id,
			IsActive = true,
			CreatedAt = DateTime.UtcNow,
		};

		var c4 = new Category
		{
			Id = Guid.NewGuid(),
			Name = "Football",
			ParentId = c2.Id,
			IsActive = true,
			CreatedAt = DateTime.UtcNow,
		};

		var c5 = new Category
		{
			Id = Guid.NewGuid(),
			Name = "NBA",
			ParentId = c3.Id,
			IsActive = true,
			CreatedAt = DateTime.UtcNow,
		};

		var c6 = new Category
		{
			Id = Guid.NewGuid(),
			Name = "Euroleague",
			ParentId = c3.Id,
			IsActive = true,
			CreatedAt = DateTime.UtcNow,
		};

		list.AddRange([c1, c2, c3, c4, c5, c6]);

		return list;
	}
}