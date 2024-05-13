using InkWell.Domain.Entities.Application;
using InkWell.Domain.Entities.Application_lu;
using Microsoft.EntityFrameworkCore;

namespace InkWell.Persistence.Contexts;

public partial class InkWellContext
{
	// Entity_lu Tables

	public virtual DbSet<Role_lu> Roles_lu { get; set; }
	public virtual DbSet<ActionType_lu> ActionTypes_lu { get; set; }
	public virtual DbSet<EntityType_lu> EntityTypes_lu { get; set; }

	// Application

	public virtual DbSet<User> Users { get; set; }
	public virtual DbSet<UserRole> UserRoles { get; set; }
	public virtual DbSet<Category> Categories { get; set; }
	public virtual DbSet<Post> Posts { get; set; }
	public virtual DbSet<ErrorLog> ErrorLogs { get; set; }
	public virtual DbSet<SigninLog> SigninLogs { get; set; }
	public virtual DbSet<Audit> Audits { get; set; }
}