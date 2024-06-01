using AutoMapper;
using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos._BaseDto;
using InkWell.Application.Dtos.Post;
using InkWell.Application.Helpers;
using InkWell.Application.Identity.Extensions;
using InkWell.Application.Utilities;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;

namespace InkWell.Application.BusinessLogic.Posts.Queries.GetFypPosts;

internal class GetFollowingPostsQueryHandler : BaseHandler, IQueryHandler<GetFollowingPostsQuery, GridDto<ResponsePostDto>>
{
	public GetFollowingPostsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
	{
	}

	public async Task<Result<GridDto<ResponsePostDto>>> Handle(GetFollowingPostsQuery request, CancellationToken cancellationToken)
	{
		var currentUser = UserContext.CurrentUserId;
		var posts = await UnitOfWork.PostRepository.GetAllFollowingPostsAsync(request.EntryParams, currentUser, cancellationToken);

		if (posts.Count < 1)
		{
			return Result.Failure<GridDto<ResponsePostDto>>(Error<Post>.NotFound);
		}

		var mappedResults = Mapper.Map<IEnumerable<ResponsePostDto>>(posts.Results);

		var result = MakeGridResponse<ResponsePostDto>.Create(request.EntryParams, mappedResults, posts.Count);

		return Result.Success(result);
	}
}