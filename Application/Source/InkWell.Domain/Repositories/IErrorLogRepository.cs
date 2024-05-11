using InkWell.Domain.Entities.Application;

namespace InkWell.Domain.Repositories;

public interface IErrorLogRepository
{
	void Add(ErrorLog log);
}