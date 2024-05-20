using InkWell.Application.Dtos._BaseDto;
using InkWell.Domain.Utilities.Params;

namespace InkWell.Application.Helpers;

internal class MakeGridResponse<T>
    where T : BaseDto
{
    public static GridDto<T> Create(EntryParams entryParams, IEnumerable<T> items, int totalCount)
    {
        return new GridDto<T>
        {
            Params = new ResponseParams
            {
                ItemCount = totalCount,
                PageNumber = entryParams.PageNumber,
                PageSize = entryParams.PageSize,
                SortColumn = entryParams.SortColumn,
                SortDirection = entryParams.SortDirection,
                QuickSearch = entryParams.QuickSearch,
            },
            Items = items
        };
    }
}