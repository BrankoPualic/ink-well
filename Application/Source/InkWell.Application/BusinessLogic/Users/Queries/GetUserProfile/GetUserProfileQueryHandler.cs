using AutoMapper;
using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos.User;
using InkWell.Application.Utilities;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;

namespace InkWell.Application.BusinessLogic.Users.Queries.GetUserProfile;

internal class GetUserProfileQueryHandler : BaseHandler, IQueryHandler<GetUserProfileQuery, ProfileDto>
{
	public GetUserProfileQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
	{
	}

	public async Task<Result<ProfileDto>> Handle(GetUserProfileQuery request, CancellationToken cancellationToken)
	{
		var user = await UnitOfWork.UserRepository.GetUserProfileAsync(request.UserId, cancellationToken);

		if (user is null)
		{
			return Result.Failure<ProfileDto>(Error<User>.NotFound);
		}

		var mappedResult = Mapper.Map<ProfileDto>(user);

		return Result.Success(mappedResult);
	}
}