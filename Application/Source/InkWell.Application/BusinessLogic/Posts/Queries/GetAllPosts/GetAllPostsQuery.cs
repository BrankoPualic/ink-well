using AutoMapper;
using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos._BaseDto;
using InkWell.Application.Dtos.Post;
using InkWell.Application.Helpers;
using InkWell.Application.Utilities;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;
using InkWell.Domain.Utilities.Params;

namespace InkWell.Application.BusinessLogic.Posts.Queries.GetAllPosts;
public sealed record GetAllPostsQuery(EntryParams EntryParams, Guid? CategoryId) : IQuery<GridDto<ResponsePostDto>>;

internal class GetAllPostsQueryHandler : BaseHandler, IQueryHandler<GetAllPostsQuery, GridDto<ResponsePostDto>>
{
	public GetAllPostsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
	{
	}

	public async Task<Result<GridDto<ResponsePostDto>>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
	{
		var posts = await UnitOfWork.PostRepository.GetAllAsync(request.EntryParams, request.CategoryId, cancellationToken);

		if (posts.Count < 1)
		{
			return Result.Failure<GridDto<ResponsePostDto>>(Error<Post>.NotFound);
		}

		var mappedResults = Mapper.Map<IEnumerable<ResponsePostDto>>(posts.Results);

		var result = MakeGridResponse<ResponsePostDto>.Create(request.EntryParams, mappedResults, posts.Count);

		return Result.Success(result);
	}
}