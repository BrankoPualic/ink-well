using InkWell.Application.Dtos._BaseDto;

namespace InkWell.Application.Dtos.Role;

public class RoleDto : BaseDto
{
	public IEnumerable<string> Roles { get; set; } = new HashSet<string>();
}