using InkWell.Domain.Entities.Application;
using InkWell.Persistence.Contexts;
using InkWell.Persistence.Repositories.Context;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace InkWell.Persistence.Helpers;

public class RepositoryHelpers : RepositoryContext
{
	public RepositoryHelpers(InkWellContext context) : base(context)
	{
	}

	public static async Task LoadCategoryChildrenRecursively(Category category, InkWellContext context, CancellationToken cancellationToken)
	{
		if (category is null || category.Children.Count == 0)
			return;

		foreach (var child in category.Children)
		{
			await context.Entry(child).Collection(x => x.Children).LoadAsync(cancellationToken);
			await LoadCategoryChildrenRecursively(child, context, cancellationToken);
		}
	}

	public static IEnumerable<Category> FilterActiveCategories(IEnumerable<Category> categories)
	{
		var result = new List<Category>();

		foreach (var category in categories)
		{
			if (category.IsActive)
			{
				var activeChildren = FilterActiveCategories(category.Children);
				category.Children = activeChildren.ToList();
				result.Add(category);
			}
		}

		return result;
	}

	public static IEnumerable<Comment> FilterActiveComments(Guid postId, IEnumerable<Comment> comments)
	{
		var result = new List<Comment>();

		foreach (var comment in comments)
		{
			if (comment.IsActive)
			{
				var activeReplies = FilterActiveComments(postId, comment.Replies);
				comment.Replies = activeReplies.ToList();
				result.Add(comment);
			}
		}

		return result;
	}

	public static IEnumerable<Comment> FlattenComments(IEnumerable<Comment> comments)
	{
		var flatList = new List<Comment>();

		void Flatten(Comment comment)
		{
			foreach (var reply in comment.Replies)
			{
				flatList.Add(reply);
				Flatten(reply);
			}
		}

		foreach (var comment in comments)
		{
			Flatten(comment);
		}

		return flatList;
	}

	public static async Task LoadCommentsChildrenRecursively(IEnumerable<Comment> comments, InkWellContext context, CancellationToken cancellationToken)
	{
		if (comments is null)
			return;

		foreach (var comment in comments)
		{
			if (comment.Replies.Count == 0)
			{
				return;
			}

			foreach (var reply in comment.Replies)
			{
				await context.Entry(reply).Collection(x => x.Replies).LoadAsync(cancellationToken);
				await LoadCommentsChildrenRecursively(comment.Replies, context, cancellationToken);
			}
		}
	}
}