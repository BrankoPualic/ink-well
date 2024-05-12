using InkWell.Domain.Entities.Application;
using InkWell.Domain.Interfaces;
using InkWell.Domain.Repositories;

namespace InkWell.Infrastructure.Logger;

public class DbExceptionLogger : IExceptionLogger
{
	private readonly IUnitOfWork _unitOfWork;

	public DbExceptionLogger(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public IUnitOfWork UnitOfWork => _unitOfWork;

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

		UnitOfWork.ErrorLogRepository.Add(log);

		UnitOfWork.Complete();

		return id;
	}
}