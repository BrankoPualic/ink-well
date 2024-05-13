using AutoMapper;
using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos.Audit;
using InkWell.Application.Utilities;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;

namespace InkWell.Application.BusinessLogic.Audits.Queries.GetAllAudits;
public sealed record GetAllAuditsQuery : IQuery<IEnumerable<AuditDto>>;

public class GetAllAuditsQueryHandler : BaseHandler, IQueryHandler<GetAllAuditsQuery, IEnumerable<AuditDto>>
{
	public GetAllAuditsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
		: base(unitOfWork, mapper)
	{
	}

	public async Task<Result<IEnumerable<AuditDto>>> Handle(GetAllAuditsQuery request, CancellationToken cancellationToken)
	{
		var audits = await UnitOfWork.AuditRepository.GetAllAsync(cancellationToken);

		if (audits == null)
		{
			return Result.Failure<IEnumerable<AuditDto>>(Error<Audit>.NotFound);
		}

		var mappedAudits = Mapper.Map<IEnumerable<AuditDto>>(audits);

		return Result.Success(mappedAudits);
	}
}