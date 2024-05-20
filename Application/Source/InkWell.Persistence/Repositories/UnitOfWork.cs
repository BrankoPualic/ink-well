using InkWell.Domain.Entities.BaseEntities;
using InkWell.Domain.Repositories;
using InkWell.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace InkWell.Persistence.Repositories;

public class UnitOfWork : IUnitOfWork
{
	private readonly InkWellContext _context;

	public UnitOfWork(InkWellContext context)
	{
		_context = context;
	}

	public IUserRepository UserRepository => new UserRepository(_context);

	public ICategoryRepository CategoryRepository => new CategoryRepository(_context);

	public IPostRepository PostRepository => new PostRepository(_context);

	public IErrorLogRepository ErrorLogRepository => new ErrorLogRepository(_context);

	public ISigninLogRepository SigninLogRepository => new SigninLogRepository(_context);

	public IAuditRepository AuditRepository => new AuditRepository(_context);

	public async Task<bool> Complete()
	{
		return await _context.SaveChangesAsync() > 0;
	}

	public bool HasChanges()
	{
		return _context.ChangeTracker.HasChanges();
	}
}