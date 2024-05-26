using InkWell.Application.Dtos.Category;
using InkWell.Domain.Entities.Application;

namespace InkWell.Application.Mapper;

public class CategoryMapper : AutoMapperProfile
{
	public CategoryMapper()
	{
		CreateMap<Category, ResponseCategoryDto>();
	}
}