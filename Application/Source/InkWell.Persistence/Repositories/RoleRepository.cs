using InkWell.Domain.Entities.Application;
using InkWell.Domain.Entities.Application_lu;
using InkWell.Domain.Repositories;
using InkWell.Persistence.Contexts;
using InkWell.Persistence.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace InkWell.Persistence.Repositories;

public class RoleRepository : RepositoryContext, IRoleRepository
{
	public RoleRepository(InkWellContext context) : base(context)
	{
	}

	public void AddUserRole(UserRole userRole)
	{
		Context.UserRoles.Add(userRole);
	}

	public async Task<IEnumerable<Role_lu>> GetAllAsync(CancellationToken cancellationToken = default)
	{
		return await Context.Roles_lu.ToListAsync(cancellationToken);
	}

	public async Task<IEnumerable<UserRole>> GetUserRolesAsync(Guid id, CancellationToken cancellationToken = default)
	{
		return await Context.UserRoles
			.Include(x => x.Role)
			.Where(x => x.UserId.Equals(id))
			.ToListAsync(cancellationToken);
	}

	public async Task<bool> RolesExistAsync(IEnumerable<string> roles, CancellationToken cancellationToken = default)
	{
		int matchingRolesCount = await Context.UserRoles
			.Include(x => x.Role)
			.Where(x => roles.Contains(x.Role.Name))
			.CountAsync(cancellationToken);

		return matchingRolesCount == roles.Count();
	}
}