namespace InkWell.Application.Utilities;

public static class EnumUtilities
{
	public static bool TryGetEnum<TEnum>(string input, out TEnum enumType) where TEnum : struct, Enum
	{
		return Enum.TryParse(input, true, out enumType);
	}

	public static TEnum GetEnum<TEnum>(string input) where TEnum : struct, Enum
	{
		if (TryGetEnum<TEnum>(input, out var enumValue))
		{
			return enumValue;
		}

		throw new ArgumentException($"Invliad enum type: {input}");
	}

	public static TEnum[] GetAllEnumValues<TEnum>() where TEnum : struct, Enum
	{
		return (TEnum[])Enum.GetValues(typeof(TEnum));
	}

	public static string GetEnumName<TEnum>(TEnum enumValue) where TEnum : struct, Enum
	{
		return Enum.GetName(typeof(TEnum), enumValue)!;
	}
}