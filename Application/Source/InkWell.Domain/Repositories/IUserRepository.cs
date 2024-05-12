using InkWell.Domain.Entities.Application;

namespace InkWell.Domain.Repositories;

public interface IUserRepository
{
	Task AddAsync(User user, UserRole role, CancellationToken cancellationToken = default);

	Task<bool> UserExistByEmailAsync(string email, CancellationToken cancellationToken = default);

	Task<bool> UserExistByUsernameAsync(string username, CancellationToken cancellationToken = default);

	Task<bool> UserStillActiveAsync(string email, CancellationToken cancellationToken = default);

	Task<User> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default);
}