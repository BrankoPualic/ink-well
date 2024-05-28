using AutoMapper;
using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos.Post;
using InkWell.Application.Utilities;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;

namespace InkWell.Application.BusinessLogic.Posts.Queries.GetPost;

internal class GetPostQueryHandler : BaseHandler, IQueryHandler<GetPostQuery, ResponsePostDto>
{
	public GetPostQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
	{
	}

	public async Task<Result<ResponsePostDto>> Handle(GetPostQuery request, CancellationToken cancellationToken)
	{
		var post = await UnitOfWork.PostRepository.GetPostAsync(request.PostId, cancellationToken);

		if (post.Post is null)
		{
			return Result.Failure<ResponsePostDto>(Error<Post>.NotFound);
		}

		var mappedResult = Mapper.Map<ResponsePostDto>(post);

		return Result.Success(mappedResult);
	}
}