namespace InkWell.Domain.Entities.Application;

public class SigninLog
{
	public Guid SessionId { get; set; }
	public Guid UserId { get; set; }
	public DateTime Time { get; set; }
	public virtual User User { get; set; }
}