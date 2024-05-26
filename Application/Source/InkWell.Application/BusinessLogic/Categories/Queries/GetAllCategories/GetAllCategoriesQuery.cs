using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos.Category;

namespace InkWell.Application.BusinessLogic.Categories.Queries.GetAllCategories;
public sealed record GetAllCategoriesQuery : IQuery<IEnumerable<ResponseCategoryDto>>;