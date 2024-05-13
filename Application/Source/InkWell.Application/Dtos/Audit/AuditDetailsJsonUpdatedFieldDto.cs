namespace InkWell.Application.Dtos.Audit;

public class AuditDetailsJsonUpdatedFieldDto
{
	public string Column { get; set; } = string.Empty;
	public string Old { get; set; } = string.Empty;
	public string New { get; set; } = string.Empty;
}