namespace InkWell.Application.Identity.Extensions;

public static class UserContext
{
	private static readonly AsyncLocal<UserContextData> _userContextData = new();

	public static Guid CurrentUserId
	{
		get => _userContextData.Value!.UserId;
		set => _userContextData.Value = new UserContextData { UserId = value };
	}

	internal class UserContextData
	{
		public Guid UserId { get; set; }
	}
}