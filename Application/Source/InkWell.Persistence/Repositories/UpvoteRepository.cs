using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;
using InkWell.Persistence.Contexts;
using InkWell.Persistence.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace InkWell.Persistence.Repositories;

public class UpvoteRepository : RepositoryContext, IUpvoteRepository
{
	public UpvoteRepository(InkWellContext context) : base(context)
	{
	}

	public async Task<Upvote> GetUpvoteAsync(Guid userId, Guid commentId, CancellationToken cancellationToken = default)
	{
		return await Context.Upvotes.SingleOrDefaultAsync(
			x => x.UserId.Equals(userId)
			&& x.CommentId.Equals(commentId),
			cancellationToken);
	}

	public void Upvote(Upvote upvote)
	{
		Context.Upvotes.Add(upvote);
	}
}