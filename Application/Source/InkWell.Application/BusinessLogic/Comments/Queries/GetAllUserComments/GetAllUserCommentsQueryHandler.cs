using AutoMapper;
using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos._BaseDto;
using InkWell.Application.Dtos.Comment;
using InkWell.Application.Helpers;
using InkWell.Application.Identity.Extensions;
using InkWell.Application.Utilities;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;

namespace InkWell.Application.BusinessLogic.Comments.Queries.GetAllUserComments;

internal class GetAllUserCommentsQueryHandler : BaseHandler, IQueryHandler<GetAllUserCommentsQuery, GridDto<ResponseCommentDto>>
{
	public GetAllUserCommentsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
	{
	}

	public async Task<Result<GridDto<ResponseCommentDto>>> Handle(GetAllUserCommentsQuery request, CancellationToken cancellationToken)
	{
		var currentUser = UserContext.CurrentUserId;

		var comments = await UnitOfWork.CommentRepository.GetAllUserCommentsAsync(request.EntryParams, currentUser, cancellationToken);

		if (comments.Count < 1)
		{
			return Result.Failure<GridDto<ResponseCommentDto>>(Error<Comment>.NotFound);
		}

		var mappedResults = Mapper.Map<IEnumerable<ResponseCommentDto>>(comments.Results);

		var result = MakeGridResponse<ResponseCommentDto>.Create(request.EntryParams, mappedResults, comments.Count);

		return Result.Success(result);
	}
}