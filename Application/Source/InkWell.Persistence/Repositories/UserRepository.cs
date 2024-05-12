using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;
using InkWell.Persistence.Contexts;
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

	public async Task<bool> UserExistAsync(string value, string column, CancellationToken cancellationToken = default)
	{
		bool exist = true;
		if (column.Equals("email", StringComparison.CurrentCultureIgnoreCase))
		{
			exist = await Context.Users.SingleOrDefaultAsync(x => x.Email == value, cancellationToken) is not null;
		}
		else if (column.Equals("username", StringComparison.CurrentCultureIgnoreCase))
		{
			exist = await Context.Users.SingleOrDefaultAsync(x => x.Username == value, cancellationToken) is not null;
		}
		return exist;
	}

	public async Task<bool> UserStillActiveAsync(Guid userId, CancellationToken cancellationToken = default)
	{
		bool exist = await Context.Users.SingleOrDefaultAsync(
			x => x.Id == userId
			&& x.IsActive,
			cancellationToken) is not null;
		return exist;
	}
}