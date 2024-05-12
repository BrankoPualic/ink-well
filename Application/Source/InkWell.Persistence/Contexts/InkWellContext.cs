using InkWell.Application.Identity.Extensions;
using InkWell.Domain.Entities.BaseEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace InkWell.Persistence.Contexts;

public partial class InkWellContext : DbContext
{
	private readonly string _connectionString;

	public InkWellContext()
	{
		_connectionString = "Data Source=localhost;Initial Catalog=InkWell;TrustServerCertificate=true;Integrated security = true";
	}

	public InkWellContext(string connectionString) : base()
	{
		_connectionString = connectionString;
	}

	public InkWellContext(DbContextOptions<InkWellContext> options) : base(options)
	{
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		if (!optionsBuilder.IsConfigured)
		{
			optionsBuilder.UseSqlServer(_connectionString);
		}

		base.OnConfiguring(optionsBuilder);
	}

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		modelBuilder.ApplyConfigurationsFromAssembly(this.GetType().Assembly);

		base.OnModelCreating(modelBuilder);
	}

	public override int SaveChanges()
	{
		SaveByEntityState();

		return base.SaveChanges();
	}

	public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
	{
		SaveByEntityState();

		return base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
	}

	private void SaveByEntityState()
	{
		IEnumerable<EntityEntry> entries = this.ChangeTracker.Entries();

		foreach (EntityEntry entry in entries)
		{
			if (entry.State == EntityState.Added)
			{
				if (entry.Entity is Entity e)
				{
					e.IsActive = true;
					e.CreatedAt = DateTime.UtcNow;
				}
			}

			if (entry.State == EntityState.Modified)
			{
				if (entry.Entity is Entity e)
				{
					e.ModifiedAt = DateTime.UtcNow;
					e.ModifiedBy = UserContext.CurrentUserId;
				}
			}

			if (entry.State == EntityState.Deleted)
			{
				if (entry.Entity is Entity e)
				{
					e.DeletedAt = DateTime.UtcNow;
					e.DeletedBy = UserContext.CurrentUserId;
				}
			}
		}
	}
}