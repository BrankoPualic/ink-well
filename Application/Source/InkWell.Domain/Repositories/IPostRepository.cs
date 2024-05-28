using InkWell.Domain.Entities.Application;
using InkWell.Domain.Utilities._DbResponses;
using InkWell.Domain.Utilities._DbResponses.Posts;
using InkWell.Domain.Utilities.Params;

namespace InkWell.Domain.Repositories;

public interface IPostRepository
{
	Task<DbGetAllResponse<PostDbResponse>> GetAllAsync(EntryParams entryParams, Guid? categoryId, CancellationToken cancellationToken = default);

	Task<Post> GetPostByIdAsync(Guid postId, CancellationToken cancellationToken = default);

	void AddPost(Post post);

	Task<PostDbResponse> GetPostAsync(Guid postId, CancellationToken cancellationToken = default);
}