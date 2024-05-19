namespace InkWell.Common.Extensions;

public static class StringExtensions
{
	public static bool HasValue(this string value)
	{
		if (value is null) return false;
		return !string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value);
	}
}