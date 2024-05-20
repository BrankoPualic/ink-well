using InkWell.Common.Extensions;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;
using InkWell.Domain.Utilities._DbResponses;
using InkWell.Domain.Utilities.Filters;
using InkWell.Domain.Utilities.Params;
using InkWell.Persistence.Contexts;
using InkWell.Persistence.Extensions;
using InkWell.Persistence.Helpers;
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

	public async Task<DbGetAllResponse<Audit>> GetAllAsync(EntryAuditFilters filters, EntryParams entryParams, CancellationToken cancellationToken)
	{
		var query = Context.Audits.Include(x => x.User).ThenInclude(x => x.UserRoles).ThenInclude(x => x.Role).AsQueryable();

		query = AuditHelper.ApplyAuditFiltering(query, filters);

		if (entryParams.QuickSearch.HasValue())
		{
			query = query.Where(x => x.User.Username.Contains(entryParams.QuickSearch, StringComparison.CurrentCultureIgnoreCase));
		}

		int totalCount = await query.CountAsync(cancellationToken);

		query = query.ApplyParams(entryParams);

		DbGetAllResponse<Audit> result = new()
		{
			Count = totalCount,
			Results = await query.ToListAsync(cancellationToken)
		};

		return result;
	}
}