namespace InkWell.Domain.Abstractions;

public interface IExceptionLogger
{
	Guid LogException(Exception exception);
}