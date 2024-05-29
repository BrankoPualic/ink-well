using InkWell.Application.Dtos.Comment;
using InkWell.Domain.Entities.Application;

namespace InkWell.Application.Helpers;

public static class QueryHelpers
{
	public static ResponseCommentDto MapComment(Comment comment)
	{
		var mappedComment = new ResponseCommentDto
		{
			Id = comment.Id,
			Title = comment.Title,
			Text = comment.Text,
			ParentId = comment.ParentId,
			CreatedAt = comment.CreatedAt,
			ModifiedAt = comment.ModifiedAt,
			Upvotes = comment.Upvotes.Count(),
			Replies = comment.Replies.Count(),
			User = new Dtos.User.ProfileDto
			{
				Id = comment.User.Id,
				Username = comment.User.Username,
				ProfilePictureUrl = comment.User.ProfilePictureUrl,
				FullName = comment.User.FullName,
				DateOfBirth = comment.User.DateOfBirth,
				Followers = comment.User.Followers.Count(),
				Following = comment.User.Following.Count()
			},
			ReplyComments = comment.Replies.Select(MapComment).ToList()
		};

		return mappedComment;
	}
}