using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;
using InkWell.Persistence.Contexts;
using InkWell.Persistence.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace InkWell.Persistence.Repositories;

public class AuditRepository : RepositoryContext, IAuditRepository
{
	public AuditRepository(InkWellContext context) : base(context)
	{
	}

	public void Add(Audit audit)
	{
		Context.Add(audit);
	}

	public async Task<IEnumerable<Audit>> GetAllAsync(CancellationToken cancellationToken)
	{
		return await Context.Audits
			.Include(x => x.User)
			.ThenInclude(x => x.UserRoles)
			.ToListAsync(cancellationToken);
	}
}