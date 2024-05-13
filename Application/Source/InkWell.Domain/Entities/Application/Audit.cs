namespace InkWell.Domain.Entities.Application;

public class Audit
{
	public Guid Id { get; set; }
	public Guid EntitiyId { get; set; }
	public int EntitiyTypeId { get; set; }
	public int ActionTypeId { get; set; }
	public bool IsSuccess { get; set; }
	public string? DetailsJson { get; set; }
	public DateTime Time { get; set; }
	public Guid ExecutedBy { get; set; }
	public virtual User User { get; set; }
}