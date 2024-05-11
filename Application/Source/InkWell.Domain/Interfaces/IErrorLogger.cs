namespace InkWell.Domain.Interfaces;

public interface IErrorLogger
{
	Guid LogError(Exception exception);
}