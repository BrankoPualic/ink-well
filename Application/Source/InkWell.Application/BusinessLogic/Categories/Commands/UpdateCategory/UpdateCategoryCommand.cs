using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos.Category;

namespace InkWell.Application.BusinessLogic.Categories.Commands.UpdateCategory;
public sealed record UpdateCategoryCommand(Guid Id, EntryUpdateCategoryDto Cateogry) : ICommand;