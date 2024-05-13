using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;
using InkWell.Persistence.Contexts;
using InkWell.Persistence.Repositories.Context;

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
}