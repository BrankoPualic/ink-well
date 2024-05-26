using InkWell.Application.Abstractions.Messaging;

namespace InkWell.Application.BusinessLogic.Categories.Commands.DeleteCategory;
public sealed record DeleteCategoryCommand(Guid Id) : ICommand;