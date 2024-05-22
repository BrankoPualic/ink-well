using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;
using InkWell.Persistence.Contexts;
using InkWell.Persistence.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace InkWell.Persistence.Repositories;

public class FollowRepository : RepositoryContext, IFollowRepository
{
	public FollowRepository(InkWellContext context) : base(context)
	{
	}

	public void Follow(Follow follow)
	{
		Context.Follows.Add(follow);
	}

	public async Task<Follow> GetFollowAsync(Guid followerId, Guid followingId, CancellationToken cancellationToken = default)
	{
		return await Context.Follows.SingleOrDefaultAsync(
			x => x.FollowerId.Equals(followerId)
			&& x.FollowingId.Equals(followingId),
			cancellationToken);
	}
}