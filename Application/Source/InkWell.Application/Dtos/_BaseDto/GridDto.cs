using InkWell.Domain.Utilities.Params;

namespace InkWell.Application.Dtos._BaseDto;

public class GridDto<T>
	where T : BaseDto
{
	public ResponseParams Params { get; set; }
	public IEnumerable<T> Items { get; set; } = new HashSet<T>();
}