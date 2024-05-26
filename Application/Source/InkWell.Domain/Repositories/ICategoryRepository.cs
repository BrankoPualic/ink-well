using InkWell.Domain.Entities.Application;

namespace InkWell.Domain.Repositories;

public interface ICategoryRepository
{
	Task<IEnumerable<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken = default);
}