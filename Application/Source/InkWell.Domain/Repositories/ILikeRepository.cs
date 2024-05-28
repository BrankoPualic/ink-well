using InkWell.Domain.Entities.Application;

namespace InkWell.Domain.Repositories;

public interface ILikeRepository
{
	Task<Like> GetLikeAsync(Guid userId, Guid postId, CancellationToken cancellationToken = default);

	void Like(Like like);
}