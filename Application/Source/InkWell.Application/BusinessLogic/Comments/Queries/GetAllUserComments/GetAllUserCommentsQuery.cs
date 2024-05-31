using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos._BaseDto;
using InkWell.Application.Dtos.Comment;
using InkWell.Domain.Utilities.Params;

namespace InkWell.Application.BusinessLogic.Comments.Queries.GetAllUserComments;
public sealed record GetAllUserCommentsQuery(EntryParams EntryParams) : IQuery<GridDto<ResponseCommentDto>>;