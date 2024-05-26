using InkWell.Common;

namespace InkWell.Application.Identity.Extensions;

public static class UserContext
{
	private static readonly AsyncLocal<UserContextData> _userContextData = new();

	public static Guid CurrentUserId
	{
		get
		{
			if (_userContextData.Value is null)
			{
				return Guid.Parse(Constants.SYSTEM_USER_ID);
			}
			return _userContextData.Value.UserId;
		}
		set => _userContextData.Value = new UserContextData { UserId = value, Roles = CurrentRoles };
	}
	
	public static List<string> CurrentRoles
	{
		get => _userContextData.Value?.Roles ?? new List<string>();
		set
		{
			if(_userContextData.Value is not null)
			{
				_userContextData.Value.Roles = value;
			}
		}
	}

	internal class UserContextData
	{
		public Guid UserId { get; set; }
		public List<string> Roles { get; set; } = new();
	}
}