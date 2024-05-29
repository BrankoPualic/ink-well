using InkWell.Domain.Entities.Application;
using InkWell.Domain.Utilities._DbResponses.Users;

namespace InkWell.Domain.Utilities._DbResponses.Comments;

public class CommentDbResponse
{
	public Comment Comment { get; set; }
	public UserDbResponse User { get; set; }
	public int Upvotes { get; set; }
	public int Replies { get; set; }
}