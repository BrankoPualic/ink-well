namespace InkWell.Domain.Entities.Application;

public class ErrorLog
{
	public Guid ErrorId { get; set; }
	public string Message { get; set; } = string.Empty;
	public string? StackTrace { get; set; }
	public DateTime Time { get; set; }
}