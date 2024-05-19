using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos._BaseDto;
using InkWell.Application.Dtos.Audit;
using InkWell.Domain.Utilities.Filters;
using InkWell.Domain.Utilities.Params;

namespace InkWell.Application.BusinessLogic.Audits.Queries.GetAllAudits;
public sealed record GetAllAuditsQuery(EntryAuditFilters Filters, EntryParams EntryParams) : IQuery<GridDto<AuditDto>>;