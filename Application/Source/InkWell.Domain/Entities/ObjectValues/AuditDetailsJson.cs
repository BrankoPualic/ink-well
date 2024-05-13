namespace InkWell.Domain.Entities.ObjectValues;

public class AuditDetailsJson
{
	public string? Reason { get; set; }

	public List<AuditDetailsJsonUpdatedField>? Updated_Fields { get; set; }
}