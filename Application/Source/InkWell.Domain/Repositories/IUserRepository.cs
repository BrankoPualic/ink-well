using InkWell.Domain.Entities.Application;
using InkWell.Domain.Entities.Application_lu;
using InkWell.Domain.Utilities._DbResponses;
using InkWell.Domain.Utilities._DbResponses.Users;
using InkWell.Domain.Utilities.Params;

namespace InkWell.Domain.Repositories;

public interface IUserRepository
{
	Task AddAsync(User user, UserRole role, CancellationToken cancellationToken = default);

	Task<bool> UserExistByEmailAsync(string email, CancellationToken cancellationToken = default);

	Task<bool> UserExistByUsernameAsync(string username, CancellationToken cancellationToken = default);

	Task<bool> UserStillActiveAsync(string email, CancellationToken cancellationToken = default);

	Task<User> GetUserByEmailAsync(string email, CancellationToken cancellationToken = default);

	Task<User> GetUserByIdAsync(Guid id, CancellationToken cancellationToken = default);

	Task<DbGetAllResponse<UserDbResponse>> GetAllByAdminAsync(EntryParams entryParams, CancellationToken cancellationToken = default);

	Task<DbGetAllResponse<UserDbResponse>> GetAllAsync(EntryParams entryParams, CancellationToken cancellationToken = default);

	Task<UserDbResponse> GetUserProfileAsync(Guid userId, CancellationToken cancellationToken = default);
}