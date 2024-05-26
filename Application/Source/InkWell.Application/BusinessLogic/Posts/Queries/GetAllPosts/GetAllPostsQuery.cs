using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos._BaseDto;
using InkWell.Application.Dtos.Post;
using InkWell.Domain.Utilities.Params;

namespace InkWell.Application.BusinessLogic.Posts.Queries.GetAllPosts;
public sealed record GetAllPostsQuery(EntryParams EntryParams, Guid? CategoryId) : IQuery<GridDto<ResponsePostDto>>;