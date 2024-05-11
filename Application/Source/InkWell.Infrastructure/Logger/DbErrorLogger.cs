using InkWell.Domain.Entities.Application;
using InkWell.Domain.Interfaces;
using InkWell.Domain.Repositories;

namespace InkWell.Infrastructure.Logger;

public class DbErrorLogger : IErrorLogger
{
	private IUnitOfWork _unitOfWork;

	public DbErrorLogger(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public Guid LogError(Exception exception)
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