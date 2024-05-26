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

	public async Task<IEnumerable<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken = default)
	{
		var categories = await Context.Categories
			.Include(x => x.Children)
			.ToListAsync();

		return categories.Where(x => !x.ParentId.HasValue).ToList();
	}
}