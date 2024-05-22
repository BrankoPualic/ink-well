using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;
using InkWell.Persistence.Contexts;
using InkWell.Persistence.Repositories.Context;

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
}