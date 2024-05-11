using FluentAssertions;
using InkWell.Common;
using InkWell.Domain.Entities.Application;
using Microsoft.EntityFrameworkCore;

namespace InkWell.Test.Database;

[TestFixture]
public class DbContextTests : GlobalDbFixtureSetupAndTeardown
{
	[Test]
	public void CanAddCategory()
	{
		Category c = new()
		{
			Id = Guid.NewGuid(),
			Name = "Test",
		};

		Fixture.Context.Entry(c).State.Should().Be(EntityState.Detached);

		Fixture.Context.Categories.Add(c);

		Fixture.Context.Entry(c).State.Should().Be(EntityState.Added);

		Fixture.Context.SaveChanges();

		c = Fixture.Context.Categories.FirstOrDefault(x => x.Name == "Test");

		c.Should().NotBeNull();
		c.Name.Should().Be("Test");
		c.IsActive.Should().BeTrue();
		c.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(500));

		Fixture.Context.Entry(c).State.Should().Be(EntityState.Unchanged);

		c.CreatedAt = DateTime.UtcNow;

		Fixture.Context.Entry(c).State.Should().Be(EntityState.Modified);

		Fixture.Context.SaveChanges();

		c = Fixture.Context.Categories.FirstOrDefault(x => x.Name == "Test");

		c.ModifiedAt.Should().NotBeNull();
		c.ModifiedBy.Should().Be(Guid.Parse(Constants.SYSTEM_USER_ID));
	}

	[Test]
	public void ThrowsException_WhenCategoryExists()
	{
		Category c = new()
		{
			Id = Guid.NewGuid(),
			Name = "Sport"
		};

		Fixture.Context.Categories.Add(c);

		Action a = () =>
		{
			Fixture.Context.SaveChanges();
		};

		a.Should().Throw<DbUpdateException>();
	}
}