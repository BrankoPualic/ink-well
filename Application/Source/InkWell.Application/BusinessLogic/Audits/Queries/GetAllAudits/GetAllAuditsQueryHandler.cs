using AutoMapper;
using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos._BaseDto;
using InkWell.Application.Dtos.Audit;
using InkWell.Application.Helpers;
using InkWell.Application.Utilities;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;

namespace InkWell.Application.BusinessLogic.Audits.Queries.GetAllAudits;

internal class GetAllAuditsQueryHandler : BaseHandler, IQueryHandler<GetAllAuditsQuery, GridDto<AuditDto>>
{
	public GetAllAuditsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
		: base(unitOfWork, mapper)
	{
	}

	public async Task<Result<GridDto<AuditDto>>> Handle(GetAllAuditsQuery request, CancellationToken cancellationToken)
	{
		var audits = await UnitOfWork.AuditRepository.GetAllAsync(request.Filters, request.EntryParams, cancellationToken);

		if (audits.Count < 1)
		{
			return Result.Failure<GridDto<AuditDto>>(Error<Audit>.NotFound);
		}

		var mappedAudits = Mapper.Map<IEnumerable<AuditDto>>(audits.Results);

		var result = MakeGridResponse<AuditDto>.Create(request.EntryParams, mappedAudits, audits.Count);

		return Result.Success(result);
	}
}