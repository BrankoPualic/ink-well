using InkWell.Domain.Repositories;
using InkWell.Persistence.Contexts;
using InkWell.Persistence.Repositories.Context;

namespace InkWell.Persistence.Repositories;

public class CategoryRepository : RepositoryContext, ICategoryRepository
{
	public CategoryRepository(InkWellContext context) : base(context)
	{
	}
}
