using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;
using InkWell.Domain.Utilities._DbResponses;
using InkWell.Domain.Utilities.Params;
using InkWell.Persistence.Contexts;
using InkWell.Persistence.Extensions;
using InkWell.Persistence.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace InkWell.Persistence.Repositories;

public class UserRepository : RepositoryContext, IUserRepository
{
	public UserRepository(InkWellContext context) : base(context)
	{
	}

	public async Task AddAsync(User user, UserRole role, CancellationToken cancellationToken = default)
	{
		List<object> entitiesToAdd = [];

		entitiesToAdd.Add(user);
		entitiesToAdd.Add(role);

		await Context.AddRangeAsync(entitiesToAdd, cancellationToken);
	}

	public async Task<bool> UserExistByEmailAsync(string email, CancellationToken cancellationToken = default)
	{
		var exist = await Context.Users.SingleOrDefaultAsync(
			x => x.Email == email, cancellationToken) is not null;

		return exist;
	}

	public async Task<bool> UserExistByUsernameAsync(string username, CancellationToken cancellationToken = default)
	{
		var exist = await Context.Users.SingleOrDefaultAsync(
			x => x.Username == username, cancellationToken) is not null;

		return exist;
	}

	public async Task<bool> UserStillActiveAsync(string email, CancellationToken cancellationToken = default)
	{
		bool exist = await Context.Users.SingleOrDefaultAsync(
			x => x.Email == email
			&& x.IsActive,
			cancellationToken) is not null;
		return exist;
	}

	public async Task<User> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default)
	{
		return await Context.Users
			.Include(x => x.UserRoles.Where(ur => ur.IsActive))
			.ThenInclude(x => x.Role)
			.SingleOrDefaultAsync(x => x.Email == email && x.IsActive, cancellationToken);
	}

	public async Task<DbGetAllResponse<User>> GetAllByAdminAsync(EntryParams entryParams, CancellationToken cancellationToken = default)
	{
		var query = Context.Users
			.Include(x => x.UserRoles.Where(ur => ur.IsActive))
			.ThenInclude(x => x.Role)
			.AsQueryable();

		int totalCount = await query.CountAsync(cancellationToken);

		query = query.ApplyParams(entryParams, "Username");

		return new DbGetAllResponse<User>
		{
			Count = totalCount,
			Results = await query.ToListAsync(cancellationToken)
		};
	}

	public async Task<DbGetAllResponse<User>> GetAllAsync(EntryParams entryParams, CancellationToken cancellationToken = default)
	{
		var query = Context.Users.AsQueryable();

		int totalCount = await query.CountAsync(cancellationToken);

		query = query.ApplyParams(entryParams, "Username");

		return new DbGetAllResponse<User>
		{
			Count = totalCount,
			Results = await query.ToListAsync(cancellationToken)
		};
	}

	public async Task<User> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default)
	{
		return await Context.Users.FindAsync(id, cancellationToken);
	}

	public async Task<IEnumerable<UserRole>> GetUserRolesAsync(Guid id, CancellationToken cancellationToken = default)
	{
		return await Context.UserRoles.Where(x => x.UserId.Equals(id)).ToListAsync(cancellationToken);
	}
}