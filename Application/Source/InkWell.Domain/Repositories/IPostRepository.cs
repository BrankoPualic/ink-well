using InkWell.Domain.Utilities._DbResponses;
using InkWell.Domain.Utilities._DbResponses.Posts;
using InkWell.Domain.Utilities.Params;

namespace InkWell.Domain.Repositories;

public interface IPostRepository
{
	Task<DbGetAllResponse<PostDbResponse>> GetAllAsync(EntryParams entryParams, Guid? categoryId, CancellationToken cancellationToken = default);
}