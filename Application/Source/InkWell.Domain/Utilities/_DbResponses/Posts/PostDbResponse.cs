using InkWell.Domain.Entities.Application;
using InkWell.Domain.Utilities._DbResponses.Users;

namespace InkWell.Domain.Utilities._DbResponses.Posts;

public class PostDbResponse
{
	public Post Post { get; set; }
	public UserDbResponse Author { get; set; }
	public int Comments { get; set; }
	public int Likes { get; set; }
}