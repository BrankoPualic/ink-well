using FluentAssertions;
using InkWell.Common;
using InkWell.Domain.Entities.Application;
using Microsoft.EntityFrameworkCore;

namespace InkWell.Test.Database;

[TestFixture]
public class DbContextTests
{
	private static DatabaseFixture _fixture;

	[OneTimeSetUp]
	public void GlobalSetup()
	{
		_fixture = new DatabaseFixture();
	}

	[Test]
	public void CanAddCategory()
	{
		Category c = new()
		{
			Id = Guid.NewGuid(),
			Name = "Test",
		};

		_fixture.Context.Entry(c).State.Should().Be(EntityState.Detached);

		_fixture.Context.Categories.Add(c);

		_fixture.Context.Entry(c).State.Should().Be(EntityState.Added);

		_fixture.Context.SaveChanges();

		c = _fixture.Context.Categories.FirstOrDefault(x => x.Name == "Test");

		c.Should().NotBeNull();
		c.Name.Should().Be("Test");
		c.IsActive.Should().BeTrue();
		c.CreatedAt.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(500));

		_fixture.Context.Entry(c).State.Should().Be(EntityState.Unchanged);

		c.CreatedAt = DateTime.UtcNow;

		_fixture.Context.Entry(c).State.Should().Be(EntityState.Modified);

		_fixture.Context.SaveChanges();

		c = _fixture.Context.Categories.FirstOrDefault(x => x.Name == "Test");

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

		_fixture.Context.Categories.Add(c);

		Action a = () =>
		{
			_fixture.Context.SaveChanges();
		};

		a.Should().Throw<DbUpdateException>();
	}

	[OneTimeTearDown]
	public void GlobalTeardown()
	{
		_fixture.Dispose();
	}
}