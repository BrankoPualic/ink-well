using InkWell.Domain.Entities.Application;

namespace InkWell.Domain.Repositories;

public interface IFollowRepository
{
	void Follow(Follow follow);

	Task<Follow> GetFollowAsync(Guid followerId, Guid followingId, CancellationToken cancellationToken = default);
}