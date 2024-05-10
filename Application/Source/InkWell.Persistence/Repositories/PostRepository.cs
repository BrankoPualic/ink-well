using InkWell.Domain.Repositories;
using InkWell.Persistence.Contexts;
using InkWell.Persistence.Repositories.Context;

namespace InkWell.Persistence.Repositories;

public class PostRepository : RepositoryContext, IPostRepository
{
	public PostRepository(InkWellContext context) : base(context)
	{
	}
}
