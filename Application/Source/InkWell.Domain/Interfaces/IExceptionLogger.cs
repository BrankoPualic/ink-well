namespace InkWell.Domain.Interfaces;

public interface IExceptionLogger
{
	Guid LogException(Exception exception);
}