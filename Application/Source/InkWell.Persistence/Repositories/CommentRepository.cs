using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;
using InkWell.Domain.Utilities._DbResponses;
using InkWell.Domain.Utilities._DbResponses.Comments;
using InkWell.Domain.Utilities._DbResponses.Users;
using InkWell.Domain.Utilities.Params;
using InkWell.Persistence.Contexts;
using InkWell.Persistence.Extensions;
using InkWell.Persistence.Helpers;
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

	public async Task<DbGetAllResponse<CommentDbResponse>> GetAllPostCommentsAsync(
		EntryParams entryParams,
		Guid postId,
		CancellationToken cancellationToken = default)
	{
		var topLevelComments = await Context.Comments
			.Include(x => x.User)
			.Include(x => x.Replies)
			.Where(x => x.PostId.Equals(postId) && x.IsActive && x.ParentId.Equals(null))
			.ApplyParams(entryParams)
			.ToListAsync();

		int totalCount = await Context.Comments
			.Where(x => x.PostId.Equals(postId) && x.IsActive)
			.CountAsync();

		await RepositoryHelpers.LoadCommentsChildrenRecursively(topLevelComments, Context, cancellationToken);

		return new DbGetAllResponse<CommentDbResponse>
		{
			Count = totalCount,
			Results = topLevelComments.Select(x => new CommentDbResponse
			{
				Comment = x,
				User = new UserDbResponse
				{
					User = x.User,
					Followers = x.User.Followers.Count(),
					Following = x.User.Following.Count(),
					Posts = x.User.Posts.Count(),
				},
				Upvotes = x.Upvotes.Count(),
				Replies = x.Replies.Count(),
			}).ToList()
		};
	}

	public async Task<Comment> GetCommentByIdAsync(Guid? commentId, CancellationToken cancellationToken = default)
	{
		return await Context.Comments
			.SingleOrDefaultAsync(x => x.Id.Equals(commentId) && x.IsActive, cancellationToken);
	}
}