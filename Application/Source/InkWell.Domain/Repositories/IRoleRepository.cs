using InkWell.Domain.Entities.Application;
using InkWell.Domain.Entities.Application_lu;

namespace InkWell.Domain.Repositories;

public interface IRoleRepository
{
	Task<IEnumerable<UserRole>> GetUserRolesAsync(Guid id, CancellationToken cancellationToken = default);

	Task<bool> RolesExistAsync(IEnumerable<string> roles, CancellationToken cancellationToken = default);

	Task<IEnumerable<Role_lu>> GetAllAsync(CancellationToken cancellationToken = default);

	void AddUserRole(UserRole userRole);
}