using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;
using InkWell.Persistence.Contexts;
using InkWell.Persistence.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace InkWell.Persistence.Repositories;

public class LikeRepository : RepositoryContext, ILikeRepository
{
	public LikeRepository(InkWellContext context) : base(context)
	{
	}

	public async Task<Like> GetLikeAsync(Guid userId, Guid postId, CancellationToken cancellationToken = default)
	{
		return await Context.Likes.SingleOrDefaultAsync(
			x => x.UserId.Equals(userId)
			&& x.PostId.Equals(postId),
			cancellationToken);
	}

	public void Like(Like like)
	{
		Context.Likes.Add(like);
	}
}