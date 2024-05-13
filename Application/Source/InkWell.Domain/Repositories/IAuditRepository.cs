using InkWell.Domain.Entities.Application;

namespace InkWell.Domain.Repositories;

public interface IAuditRepository
{
	void Add(Audit audit);

	Task<IEnumerable<Audit>> GetAllAsync(CancellationToken cancellationToken);
}