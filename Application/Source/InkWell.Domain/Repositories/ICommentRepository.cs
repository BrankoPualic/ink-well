using InkWell.Domain.Entities.Application;
using InkWell.Domain.Utilities._DbResponses;
using InkWell.Domain.Utilities._DbResponses.Comments;
using InkWell.Domain.Utilities.Params;

namespace InkWell.Domain.Repositories;

public interface ICommentRepository
{
	Task<Comment> GetCommentByIdAsync(Guid? commentId, CancellationToken cancellationToken = default);

	void AddComment(Comment comment);

	Task<DbGetAllResponse<CommentDbResponse>> GetAllPostCommentsAsync(
		EntryParams entryParams,
		Guid postId,
		CancellationToken cancellationToken = default);

	Task<DbGetAllResponse<CommentDbResponse>> GetAllUserCommentsAsync(
		EntryParams entryParams,
		Guid userId,
		CancellationToken cancellationToken = default);

	Task<Comment> GetCommentAsync(Guid commentId, Guid currentUser, CancellationToken cancellationToken = default);
}