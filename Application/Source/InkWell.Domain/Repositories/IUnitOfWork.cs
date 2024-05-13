namespace InkWell.Domain.Repositories;

public interface IUnitOfWork
{
	IUserRepository UserRepository { get; }
	ICategoryRepository CategoryRepository { get; }
	IPostRepository PostRepository { get; }
	IErrorLogRepository ErrorLogRepository { get; }
	ISigninLogRepository SigninLogRepository { get; }
	IAuditRepository AuditRepository { get; }

	Task<bool> Complete();

	bool HasChanges();
}