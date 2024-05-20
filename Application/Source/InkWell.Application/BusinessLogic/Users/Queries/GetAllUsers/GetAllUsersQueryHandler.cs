using AutoMapper;
using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos._BaseDto;
using InkWell.Application.Dtos.User;
using InkWell.Application.Utilities;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;
using InkWell.Domain.Utilities.Params;

namespace InkWell.Application.BusinessLogic.Users.Queries.GetAllUsers;

internal class GetAllUsersQueryHandler : BaseHandler, IQueryHandler<GetAllUsersQuery, GridDto<PersonalInformationsDto>>
{
	public GetAllUsersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
	{
	}

	public async Task<Result<GridDto<PersonalInformationsDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
	{
		var users = await UnitOfWork.UserRepository.GetAllAsync(request.EntryParams, cancellationToken);

		if (users.Count < 1)
		{
			return Result.Failure<GridDto<PersonalInformationsDto>>(Error<User>.NotFound);
		}

		var mappedResults = Mapper.Map<IEnumerable<PersonalInformationsDto>>(users.Results);

		var result = new GridDto<PersonalInformationsDto>
		{
			Params = new ResponseParams
			{
				ItemCount = users.Count,
				PageNumber = request.EntryParams.PageNumber,
				PageSize = request.EntryParams.PageSize,
				SortColumn = request.EntryParams.SortColumn,
				SortDirection = request.EntryParams.SortDirection,
				QuickSearch = request.EntryParams.QuickSearch,
			},
			Items = mappedResults
		};

		return Result.Success(result);
	}
}