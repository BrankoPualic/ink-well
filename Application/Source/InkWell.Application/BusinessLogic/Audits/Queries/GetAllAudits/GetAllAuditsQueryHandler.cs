using AutoMapper;
using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos._BaseDto;
using InkWell.Application.Dtos.Audit;
using InkWell.Application.Utilities;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;
using InkWell.Domain.Utilities.Params;

namespace InkWell.Application.BusinessLogic.Audits.Queries.GetAllAudits;

internal class GetAllAuditsQueryHandler : BaseHandler, IQueryHandler<GetAllAuditsQuery, GridDto<AuditDto>>
{
	public GetAllAuditsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
		: base(unitOfWork, mapper)
	{
	}

	public async Task<Result<GridDto<AuditDto>>> Handle(GetAllAuditsQuery request, CancellationToken cancellationToken)
	{
		var result = await UnitOfWork.AuditRepository.GetAllAsync(request.Filters, request.EntryParams, cancellationToken);

		if (result.Count < 1)
		{
			return Result.Failure<GridDto<AuditDto>>(Error<Audit>.NotFound);
		}

		var mappedAudits = Mapper.Map<IEnumerable<AuditDto>>(result.Results);

		GridDto<AuditDto> gridDto = new()
		{
			Params = new ResponseParams
			{
				QuickSearch = request.EntryParams.QuickSearch,
				PageNumber = request.EntryParams.PageNumber,
				PageSize = request.EntryParams.PageSize,
				SortColumn = request.EntryParams.SortColumn,
				SortDirection = request.EntryParams.SortDirection,
				ItemCount = result.Count,
			},
			Items = mappedAudits
		};

		return Result.Success(gridDto);
	}
}