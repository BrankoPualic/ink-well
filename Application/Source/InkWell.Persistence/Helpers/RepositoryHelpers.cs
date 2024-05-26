using InkWell.Domain.Entities.Application;
using InkWell.Persistence.Contexts;
using InkWell.Persistence.Repositories.Context;

namespace InkWell.Persistence.Helpers;

public class RepositoryHelpers : RepositoryContext
{
	public RepositoryHelpers(InkWellContext context) : base(context)
	{
	}

	public static async Task LoadCategoryChildrenRecursively(Category category, InkWellContext context, CancellationToken cancellationToken)
	{
		if (category is null || category.Children.Count == 0)
			return;

		foreach (var child in category.Children)
		{
			await context.Entry(child).Collection(x => x.Children).LoadAsync(cancellationToken);
			await LoadCategoryChildrenRecursively(child, context, cancellationToken);
		}
	}

	public static IEnumerable<Category> FilterActiveCategories(IEnumerable<Category> categories)
	{
		var result = new List<Category>();

		foreach (var category in categories)
		{
			if (category.IsActive)
			{
				var activeChildren = FilterActiveCategories(category.Children);
				category.Children = activeChildren.ToList();
				result.Add(category);
			}
		}

		return result;
	}
}