using InkWell.Domain.Repositories;
using InkWell.Persistence.Contexts;
using InkWell.Persistence.Repositories.Context;

namespace InkWell.Persistence.Repositories;

public class UserRepository : RepositoryContext, IUserRepository
{
	public UserRepository(InkWellContext context) : base(context)
	{
	}
}