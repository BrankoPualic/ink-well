using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos.Category;

namespace InkWell.Application.BusinessLogic.Categories.Commands.AddCategory;
public sealed record AddCategoryCommand(EntryCategoryDto Category) : ICommand;
