using AutoMapper;
using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos._BaseDto;
using InkWell.Application.Dtos.Comment;
using InkWell.Application.Helpers;
using InkWell.Application.Mapper;
using InkWell.Application.Utilities;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;

namespace InkWell.Application.BusinessLogic.Comments.Queries.GetAllPostComments;

internal class GetAllPostCommentsQueryHandler : BaseHandler, IQueryHandler<GetAllPostCommentsQuery, GridDto<ResponseCommentDto>>
{
	public GetAllPostCommentsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
	{
	}

	public async Task<Result<GridDto<ResponseCommentDto>>> Handle(GetAllPostCommentsQuery request, CancellationToken cancellationToken)
	{
		var comments = await UnitOfWork.CommentRepository.GetAllPostCommentsAsync(request.EntryParams, request.PostId, cancellationToken);

		if (comments.Count < 1)
		{
			return Result.Failure<GridDto<ResponseCommentDto>>(Error<Comment>.NotFound);
		}

		var mappedResults = Mapper.Map<IEnumerable<ResponseCommentDto>>(comments.Results);

		var result = MakeGridResponse<ResponseCommentDto>.Create(request.EntryParams, mappedResults, comments.Count);

		return Result.Success(result);
	}
}