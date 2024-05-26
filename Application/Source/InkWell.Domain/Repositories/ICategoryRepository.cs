using InkWell.Domain.Entities.Application;

namespace InkWell.Domain.Repositories;

public interface ICategoryRepository
{
	Task<IEnumerable<Category>> GetAllCategoriesAsync(CancellationToken cancellationToken = default);

	void AddCategory(Category category);

	Task<bool> CategoryExistByNameAsync(string name, CancellationToken cancellationToken = default);

	Task<bool> CategoryExistByIdAsync(Guid? id, CancellationToken cancellationToken = default);

	Task<Category> GetCategoryByIdAsync(Guid id, CancellationToken cancellationToken = default);
}