using InkWell.Domain.Interfaces;
using Serilog;

namespace InkWell.Infrastructure.Logger;

public class ConsoleErrorLogger : IErrorLogger
{
	public Guid LogError(Exception exception)
	{
		var id = Guid.NewGuid();
		Log.Error(exception, $"An Error occurred\nID: {id}\n {exception.Message}");

		return id;
	}
}