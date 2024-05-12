using InkWell.Domain.Entities.Application;

namespace InkWell.Domain.Repositories;

public interface IUserRepository
{
	Task AddAsync(User user, UserRole role, CancellationToken cancellationToken = default);

	Task<bool> UserExistAsync(string value, string column, CancellationToken cancellationToken = default);

	Task<bool> UserStillActiveAsync(Guid userId, CancellationToken cancellationToken = default);
}