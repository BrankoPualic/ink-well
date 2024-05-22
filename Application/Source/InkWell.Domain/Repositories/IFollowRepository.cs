using InkWell.Domain.Entities.Application;

namespace InkWell.Domain.Repositories;

public interface IFollowRepository
{
	void Follow(Follow follow);
}