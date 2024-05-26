using InkWell.Application.Dtos._BaseDto;

namespace InkWell.Application.Dtos.Category;

public class EntryCategoryDto : BaseDto
{
	public string Name { get; set; } = string.Empty;
	public Guid? ParentId { get; set; }
}

public class EntryUpdateCategoryDto : EntryCategoryDto
{
	public bool IsActive { get; set; }
}