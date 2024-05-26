using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InkWell.Application.Dtos.Category;

public class ResponseCategoryDto
{
	public Guid Id { get; set; }
	public string Name { get; set; } = string.Empty;
	public Guid? ParentId { get; set; }
	public IEnumerable<ResponseCategoryDto>? Children { get; set; }
}