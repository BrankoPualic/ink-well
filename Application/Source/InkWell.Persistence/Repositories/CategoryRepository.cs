using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;
using InkWell.Persistence.Contexts;
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
			.ToListAsync();

		return categories.Where(x => !x.ParentId.HasValue).ToList();
	}
}