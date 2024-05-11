using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;
using InkWell.Persistence.Contexts;
using InkWell.Persistence.Repositories.Context;

namespace InkWell.Persistence.Repositories;

public class ErrorLogRepository : RepositoryContext, IErrorLogRepository
{
	public ErrorLogRepository(InkWellContext context) : base(context)
	{
	}

	public void Add(ErrorLog log)
	{
		Context.ErrorLogs.Add(log);
	}
}