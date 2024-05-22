namespace InkWell.Domain.Entities.Application;

public class Follow
{
	public Guid FollowerId { get; set; }
	public Guid FollowingId { get; set; }
	public bool IsActive { get; set; }
	public DateTime FollowedAt { get; set; }
	public virtual User Follower { get; set; }
	public virtual User Following { get; set; }
}