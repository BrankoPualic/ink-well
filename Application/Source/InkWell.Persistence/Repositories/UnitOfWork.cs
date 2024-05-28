using InkWell.Domain.Entities.BaseEntities;
using InkWell.Domain.Repositories;
using InkWell.Persistence.Contexts;
using InkWell.Persistence.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace InkWell.Persistence.Repositories;

public class UnitOfWork : RepositoryContext, IUnitOfWork
{
	public UnitOfWork(InkWellContext context) : base(context)
	{
	}

	public IUserRepository UserRepository => new UserRepository(Context);

	public ICategoryRepository CategoryRepository => new CategoryRepository(Context);

	public IPostRepository PostRepository => new PostRepository(Context);

	public IErrorLogRepository ErrorLogRepository => new ErrorLogRepository(Context);

	public ISigninLogRepository SigninLogRepository => new SigninLogRepository(Context);

	public IAuditRepository AuditRepository => new AuditRepository(Context);

	public IRoleRepository RoleRepository => new RoleRepository(Context);

	public IFollowRepository FollowRepository => new FollowRepository(Context);

	public ILikeRepository LikeRepository => new LikeRepository(Context);

	public ICommentRepository CommentRepository => new CommentRepository(Context);

	public async Task<bool> Complete()
	{
		return await Context.SaveChangesAsync() > 0;
	}

	public bool HasChanges()
	{
		return Context.ChangeTracker.HasChanges();
	}

	public void SetEntityStateToModified<T>(T entity)
		where T : Entity
	{
		Context.Entry(entity).State = EntityState.Modified;
	}
}