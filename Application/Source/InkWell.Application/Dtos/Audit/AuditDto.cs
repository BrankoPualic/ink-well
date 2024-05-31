using InkWell.Application.Dtos._BaseDto;
using InkWell.Application.Dtos.User;

namespace InkWell.Application.Dtos.Audit;

public class AuditDto : BaseDto
{
	public Guid Id { get; set; }
	public Guid EntityId { get; set; }
	public string EntityType { get; set; } = string.Empty;
	public string ActionType { get; set; } = string.Empty;
	public bool IsSuccess { get; set; }

	public AuditDetailsJsonDto? DetailsJson { get; set; }
	public DateTime Time { get; set; }

	public PersonalInformationsDto ExecutedBy { get; set; }
}