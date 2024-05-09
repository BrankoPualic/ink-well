using InkWell.Domain.Entities.Application;
using InkWell.Domain.Entities.Application_lu;
using Microsoft.EntityFrameworkCore;

namespace InkWell.Persistence.Contexts;

public partial class InkWellContext
{
	// Entity_lu Tables
	public virtual DbSet<Role_lu> Roles { get; set; }

	// Application
	public virtual DbSet<User> Users { get; set; }

	public virtual DbSet<UserRole> UserRoles { get; set; }
}