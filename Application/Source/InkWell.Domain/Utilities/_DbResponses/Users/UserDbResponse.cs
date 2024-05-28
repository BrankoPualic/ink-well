using InkWell.Domain.Entities.Application;

namespace InkWell.Domain.Utilities._DbResponses.Users;

public class UserDbResponse
{
	public User User { get; set; }
	public int Followers { get; set; }
	public int Following { get; set; }
	public int Posts { get; set; }
}