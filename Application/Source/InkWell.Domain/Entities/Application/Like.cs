namespace InkWell.Domain.Entities.Application;

public class Like
{
	public Guid UserId { get; set; }
	public Guid PostId { get; set; }
	public bool IsActive { get; set; }
	public DateTime Time { get; set; }
	public virtual User User { get; set; }
	public virtual Post Post { get; set; }
}