namespace InkWell.Common;

public sealed class Constants
{
	public const string SYSTEM_USER_ID = "00000000-0000-0000-0000-000000000001";
	public const string SYSTEM_USERADMIN_ID = "00000000-0000-0000-0000-000000000002";
	public const string SYSTEM_MODERATOR_ID = "00000000-0000-0000-0000-000000000003";
	public const string SYSTEM_BLOGGER_ID = "00000000-0000-0000-0000-000000000004";

	public const int TOKEN_EXPIRATION_TIME = 12;

	// Policies

	public const string ADMINISTRATOR = "A";
	public const string ADMINISTRATOR_USERADMIN = "AUA";
	public const string ADMINISTRATOR_USERADMIN_MODERATOR = "AUAM";
	public const string BLOGGER = "B";
	public const string MEMBER = "M";

	// Params

	public const int DEFAULT_PAGE_SIZE = 10;
	public const int MAX_PAGE_SIZE = 50;

	// Queryable Extensions

	public const string CONTAINS = "Contains";
	public const string WHERE = "Where";
	public const string ORDER_BY = "OrderBy";
	public const string ORDER_BY_DESCENDING = "OrderByDescending";

	// Seed

	public const string TRAVEL_CATEGORY_ID = "00000000-0000-0000-0000-123345123411";
}