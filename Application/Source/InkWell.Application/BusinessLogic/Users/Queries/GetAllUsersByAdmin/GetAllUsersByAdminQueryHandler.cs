using AutoMapper;
using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos._BaseDto;
using InkWell.Application.Dtos.User;
using InkWell.Application.Helpers;
using InkWell.Application.Utilities;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;

namespace InkWell.Application.BusinessLogic.Users.Queries.GetAllUsersByAdmin;

internal class GetAllUsersByAdminQueryHandler : BaseHandler, IQueryHandler<GetAllUsersByAdminQuery, GridDto<PersonalInformationsDto>>
{
	public GetAllUsersByAdminQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
	{
	}

	public async Task<Result<GridDto<PersonalInformationsDto>>> Handle(GetAllUsersByAdminQuery request, CancellationToken cancellationToken)
	{
		var users = await UnitOfWork.UserRepository.GetAllByAdminAsync(request.EntryParams, cancellationToken);

		if (users.Count < 1)
		{
			return Result.Failure<GridDto<PersonalInformationsDto>>(Error<User>.NotFound);
		}

		var mappedResults = Mapper.Map<IEnumerable<PersonalInformationsDto>>(users.Results);

		var result = MakeGridResponse<PersonalInformationsDto>.Create(request.EntryParams, mappedResults, users.Count);

		return Result.Success(result);
	}
}