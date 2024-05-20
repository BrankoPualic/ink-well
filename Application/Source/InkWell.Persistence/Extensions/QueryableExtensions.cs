using InkWell.Common;
using InkWell.Common.Enums;
using InkWell.Common.Extensions;
using InkWell.Domain.Utilities.Params;
using System.Linq.Expressions;

namespace InkWell.Persistence.Extensions;

internal static class QueryableExtensions
{
	internal static IQueryable<T> ApplyParams<T>(
		this IQueryable<T> query,
		EntryParams entryParams,
		string? searchProperty = null)
	{
		if (entryParams.QuickSearch.HasValue() && searchProperty.HasValue())
		{
			query = query.SearchByProperty(searchProperty, entryParams.QuickSearch);
		}

		if (entryParams.SortDirection.HasValue() && entryParams.SortColumn.HasValue())
		{
			query = query.OrderByProperty(entryParams.SortColumn, entryParams.SortDirection);
		}

		if (entryParams.PageNumber > 0 && entryParams.PageSize > 0)
		{
			query = query.Skip((entryParams.PageNumber - 1) * entryParams.PageSize).Take(entryParams.PageSize);
		}

		return query;
	}

	internal static IQueryable<T> SearchByProperty<T>(this IQueryable<T> source, string searchProperty, string quickSearch)
	{
		if (!quickSearch.HasValue() || !searchProperty.HasValue())
		{
			throw new ArgumentNullException(nameof(searchProperty) + nameof(quickSearch));
		}

		var type = typeof(T);
		var property = type.GetProperty(searchProperty);
		var parameter = Expression.Parameter(type, "p");
		var propertyAccess = Expression.Property(parameter, property!);

		var searchValue = Expression.Constant(quickSearch);
		var containsMethod = typeof(string).GetMethod(Constants.CONTAINS, [typeof(string)]);
		var containsExpression = Expression.Call(propertyAccess, containsMethod!, searchValue);

		var whereExpression = Expression.Lambda<Func<T, bool>>(containsExpression, parameter);
		var resultExpression = Expression.Call(
			typeof(Queryable),
			Constants.WHERE,
			[typeof(T)],
			source.Expression,
			Expression.Quote(whereExpression));

		return source.Provider.CreateQuery<T>(resultExpression);
	}

	internal static IOrderedQueryable<T> OrderByProperty<T>(this IQueryable<T> source, string sortProperty, string direction)
	{
		if (!sortProperty.HasValue() || !direction.HasValue())
		{
			throw new ArgumentNullException(nameof(sortProperty) + nameof(direction));
		}

		var methodName = direction == eSortDirection.Ascending.ToString()
			? Constants.ORDER_BY : Constants.ORDER_BY_DESCENDING;
		var type = typeof(T);
		var property = type.GetProperty(sortProperty);
		var parameter = Expression.Parameter(type, "p");
		var propertyAccess = Expression.MakeMemberAccess(parameter, property!);
		var whereExpression = Expression.Lambda(propertyAccess, parameter);
		var resultExpression = Expression.Call(
				typeof(Queryable),
				methodName,
				[type, property!.PropertyType],
				source.Expression,
				Expression.Quote(whereExpression));

		return (IOrderedQueryable<T>)source.Provider.CreateQuery<T>(resultExpression);
	}
}