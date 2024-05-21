using InkWell.Domain.Entities.BaseEntities;

namespace InkWell.Domain.Repositories;

public interface IUnitOfWork
{
	IUserRepository UserRepository { get; }
	ICategoryRepository CategoryRepository { get; }
	IPostRepository PostRepository { get; }
	IErrorLogRepository ErrorLogRepository { get; }
	ISigninLogRepository SigninLogRepository { get; }
	IAuditRepository AuditRepository { get; }
	IRoleRepository RoleRepository { get; }

	Task<bool> Complete();

	bool HasChanges();

	void SetEntityStateToModified<T>(T entity) where T : Entity;
}