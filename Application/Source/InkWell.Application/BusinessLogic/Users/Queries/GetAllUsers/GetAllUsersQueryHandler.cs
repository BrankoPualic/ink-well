using AutoMapper;
using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos._BaseDto;
using InkWell.Application.Dtos.User;
using InkWell.Application.Helpers;
using InkWell.Application.Utilities;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;

namespace InkWell.Application.BusinessLogic.Users.Queries.GetAllUsers;

internal class GetAllUsersQueryHandler : BaseHandler, IQueryHandler<GetAllUsersQuery, GridDto<UserDto>>
{
	public GetAllUsersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
	{
	}

	public async Task<Result<GridDto<UserDto>>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
	{
		var users = await UnitOfWork.UserRepository.GetAllAsync(request.EntryParams, cancellationToken);

		if (users.Count < 1)
		{
			return Result.Failure<GridDto<UserDto>>(Error<User>.NotFound);
		}

		var mappedResults = Mapper.Map<IEnumerable<UserDto>>(users.Results);

		var result = MakeGridResponse<UserDto>.Create(request.EntryParams, mappedResults, users.Count);

		return Result.Success(result);
	}
}