using InkWell.Application.Utilities;
using InkWell.Common.Enums;
using InkWell.Common.Extensions;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Utilities.Filters;

namespace InkWell.Persistence.Helpers;

internal static class AuditHelper
{
	internal static IQueryable<Audit> ApplyAuditFiltering(IQueryable<Audit> query, EntryAuditFilters filters)
	{
		if (filters.EntityType.HasValue())
		{
			int entityType = (int)EnumUtilities.GetEnum<eEntityType>(filters.EntityType);

			query = query.Where(x => x.EntitiyTypeId == entityType);
		}

		if (filters.ActionType.HasValue())
		{
			int actionType = (int)EnumUtilities.GetEnum<eActionType>(filters.ActionType);

			query = query.Where(x => x.ActionTypeId == actionType);
		}

		if (filters.ExecutedBy.HasValue())
		{
			query = query.Where(x => x.User.Username.Equals(filters.ExecutedBy));
		}

		query = query.Where(x => x.IsSuccess == filters.IsSuccess);

		if (filters.From.HasValue)
		{
			query = query.Where(x => x.Time >= filters.From);
		}

		if (filters.To.HasValue)
		{
			query = query.Where(x => x.Time <= filters.To);
		}

		return query;
	}
}