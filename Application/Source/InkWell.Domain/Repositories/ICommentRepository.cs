using InkWell.Domain.Entities.Application;

namespace InkWell.Domain.Repositories;

public interface ICommentRepository
{
	Task<Comment> GetCommentByIdAsync(Guid? commentId, CancellationToken cancellationToken = default);

	void AddComment(Comment comment);
}