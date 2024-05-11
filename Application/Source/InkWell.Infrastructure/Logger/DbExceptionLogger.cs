using InkWell.Domain.Entities.Application;
using InkWell.Domain.Interfaces;
using InkWell.Domain.Repositories;

namespace InkWell.Infrastructure.Logger;

public class DbExceptionLogger : IExceptionLogger
{
	private IUnitOfWork _unitOfWork;

	public DbExceptionLogger(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public Guid LogException(Exception exception)
	{
		var id = Guid.NewGuid();

		ErrorLog log = new()
		{
			ErrorId = id,
			Message = exception.Message,
			StackTrace = exception.StackTrace,
			Time = DateTime.UtcNow
		};

		_unitOfWork.ErrorLogRepository.Add(log);

		_unitOfWork.Complete();

		return id;
	}
}