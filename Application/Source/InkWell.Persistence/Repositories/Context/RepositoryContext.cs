using InkWell.Persistence.Contexts;

namespace InkWell.Persistence.Repositories.Context;

public abstract class RepositoryContext
{
    private readonly InkWellContext _context;

    public RepositoryContext(InkWellContext context)
    {
        _context = context;
    }
}