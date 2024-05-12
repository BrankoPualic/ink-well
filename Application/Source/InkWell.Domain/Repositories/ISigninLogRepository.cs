using InkWell.Domain.Entities.Application;

namespace InkWell.Domain.Repositories;

public interface ISigninLogRepository
{
	void Add(SigninLog log, CancellationToken cancellationToken);
}