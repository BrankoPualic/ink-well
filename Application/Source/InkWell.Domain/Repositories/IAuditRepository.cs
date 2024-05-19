using InkWell.Domain.Entities.Application;
using InkWell.Domain.Utilities._DbResponses;
using InkWell.Domain.Utilities.Filters;
using InkWell.Domain.Utilities.Params;

namespace InkWell.Domain.Repositories;

public interface IAuditRepository
{
	void Add(Audit audit);

	Task<DbGetAllResponse<Audit>> GetAllAsync(EntryAuditFilters filters, EntryParams entryParams, CancellationToken cancellationToken);
}