namespace InkWell.Application.Dtos.Audit;

public class AuditDetailsJsonDto
{
	public string? Reason { get; set; }
	public List<AuditDetailsJsonUpdatedFieldDto>? Updated_Fields { get; set; }
}
