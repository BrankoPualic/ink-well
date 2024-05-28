using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;
using InkWell.Persistence.Contexts;
using InkWell.Persistence.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace InkWell.Persistence.Repositories;

public class CommentRepository : RepositoryContext, ICommentRepository
{
	public CommentRepository(InkWellContext context) : base(context)
	{
	}

	public void AddComment(Comment comment)
	{
		Context.Comments.Add(comment);
	}

	public async Task<Comment> GetCommentByIdAsync(Guid? commentId, CancellationToken cancellationToken = default)
	{
		return await Context.Comments
			.SingleOrDefaultAsync(x => x.Id.Equals(commentId) && x.IsActive, cancellationToken);
	}
}