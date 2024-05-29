using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos._BaseDto;
using InkWell.Application.Dtos.Comment;
using InkWell.Domain.Utilities.Params;

namespace InkWell.Application.BusinessLogic.Comments.Queries.GetAllPostComments;
public sealed record GetAllPostCommentsQuery(EntryParams EntryParams, Guid PostId) : IQuery<GridDto<ResponseCommentDto>>;