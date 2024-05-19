namespace InkWell.Domain.Utilities._DbResponses;

public sealed class DbGetAllResponse<T>
{
	public int Count { get; set; }
	public IEnumerable<T> Results { get; set; } = new HashSet<T>();
}