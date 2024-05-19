using InkWell.Common;

namespace InkWell.Domain.Utilities.Params;

public class EntryParams
{
	public string? QuickSearch { get; set; }
	public int PageNumber { get; set; } = 1;

	private int _pageSize = Constants.DEFAULT_PAGE_SIZE;

	public int PageSize
	{
		get => _pageSize;
		set
		{
			if (value > Constants.MAX_PAGE_SIZE
				|| value < Constants.DEFAULT_PAGE_SIZE)
			{
				_pageSize = Constants.DEFAULT_PAGE_SIZE;
				return;
			}
			_pageSize = value;
		}
	}

	public string? SortDirection { get; set; }
	public string? SortColumn { get; set; }
}