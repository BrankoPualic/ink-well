namespace InkWell.Domain.Utilities.Filters;

public class EntryAuditFilters
{
	public string? EntityType { get; set; }
	public string? ActionType { get; set; }
	public string? ExecutedBy { get; set; }
	public Guid? EntityId { get; set; }
	public bool IsSuccess { get; set; } = true;
	public DateTime? From { get; set; }
	public DateTime? To { get; set; }
}