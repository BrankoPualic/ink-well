using InkWell.Domain.Entities.Application;

namespace InkWell.Domain.Repositories;

public interface IUpvoteRepository
{
	void Upvote(Upvote upvote);

	Task<Upvote> GetUpvoteAsync(Guid userId, Guid commentId, CancellationToken cancellationToken = default);
}