using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;
using InkWell.Persistence.Contexts;
using InkWell.Persistence.Helpers;
using InkWell.Persistence.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace InkWell.Persistence.Repositories;

public class CategoryRepository : RepositoryContext, ICategoryRepository
{
	public CategoryRepository(InkWellContext context) : base(context)
	{
	}

	public void AddCategory(Category category)
	{
		Context.Categories.Add(category);
	}

	public async Task<bool> CategoryExistByNameAsync(string name, CancellationToken cancellationToken = default)
	{
		return await Context.Categories.SingleOrDefaultAsync(
			x => x.Name.Equals(name), cancellationToken) is not null;
	}

	public async Task<bool> CategoryExistByIdAsync(Guid? id, CancellationToken cancellationToken = default)
	{
		return await Context.Categories.SingleOrDefaultAsync(
			x => x.Id.Equals(id), cancellationToken) is not null;
	}

	public async Task<IEnumerable<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken = default)
	{
		var categories = await Context.Categories
			.Include(x => x.Children)
			.Where(x => x.IsActive)
			.ToListAsync();

		var topLevelCategories = categories.Where(x => !x.ParentId.HasValue).ToList();
		return RepositoryHelpers.FilterActiveCategories(topLevelCategories);
	}

	public async Task<Category> GetCategoryByIdAsync(Guid id, CancellationToken cancellationToken = default)
	{
		var category = await Context.Categories
			.Include(x => x.Children)
			.SingleOrDefaultAsync(x => x.Id.Equals(id), cancellationToken);

		if (category is not null)
		{
			await RepositoryHelpers.LoadCategoryChildrenRecursively(category, Context, cancellationToken);
		}

		return category;
	}
}