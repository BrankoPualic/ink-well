using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;
using InkWell.Domain.Utilities._DbResponses;
using InkWell.Domain.Utilities._DbResponses.Posts;
using InkWell.Domain.Utilities._DbResponses.Users;
using InkWell.Domain.Utilities.Params;
using InkWell.Persistence.Contexts;
using InkWell.Persistence.Extensions;
using InkWell.Persistence.Repositories.Context;
using Microsoft.EntityFrameworkCore;

namespace InkWell.Persistence.Repositories;

public class PostRepository : RepositoryContext, IPostRepository
{
	public PostRepository(InkWellContext context) : base(context)
	{
	}

	public void AddPost(Post post)
	{
		Context.Posts.Add(post);
	}

	public async Task<PostDbResponse> GetPostAsync(Guid postId, CancellationToken cancellationToken = default)
	{
		return await Context.Posts
			.Include(x => x.Author)
			.Where(x => x.Id.Equals(postId) && x.IsActive)
			.Select(x => new PostDbResponse
			{
				Post = x,
				Author = new UserDbResponse
				{
					User = x.Author,
					Followers = x.Author.Followers.Count(),
					Following = x.Author.Following.Count(),
					Posts = x.Author.Posts.Count()
				},
				Comments = x.Comments.Where(c => c.IsActive).Count(),
				Likes = x.Likes.Count()
			})
			.SingleOrDefaultAsync(cancellationToken);
	}

	public async Task<Post> GetPostByIdAsync(Guid postId, CancellationToken cancellationToken = default)
	{
		return await Context.Posts
			.SingleOrDefaultAsync(x => x.Id.Equals(postId) && x.IsActive, cancellationToken);
	}

	async Task<DbGetAllResponse<PostDbResponse>> IPostRepository.GetAllAsync(EntryParams entryParams, Guid? categoryId, CancellationToken cancellationToken)
	{
		var query = Context.Posts
			.Include(x => x.Category)
			.Include(x => x.Author)
			.Where(x => x.IsActive)
			.AsQueryable();

		if (categoryId is not null)
		{
			query = query.Where(x => x.CategoryId.Equals(categoryId));
		}

		query = query.ApplyParams(entryParams, "Title");

		int totalCount = await query.CountAsync(cancellationToken);

		return new DbGetAllResponse<PostDbResponse>
		{
			Count = totalCount,
			Results = await query
				.Select(x => new PostDbResponse
				{
					Post = x,
					Author = new UserDbResponse
					{
						User = x.Author,
						Followers = x.Author.Followers.Count(),
						Following = x.Author.Following.Count(),
						Posts = x.Author.Posts.Count(),
					},
					Comments = x.Comments.Count(),
					Likes = x.Likes.Count()
				})
				.ToListAsync(cancellationToken)
		};
	}
}