namespace InkWell.Domain.Repositories;

public interface IUnitOfWork
{
	IUserRepository UserRepository { get; }
	ICategoryRepository CategoryRepository { get; }
	IPostRepository PostRepository { get; }

	Task<bool> Complete();

	bool HasChanges();
}