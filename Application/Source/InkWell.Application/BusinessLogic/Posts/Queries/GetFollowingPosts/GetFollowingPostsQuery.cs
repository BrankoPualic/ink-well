using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos._BaseDto;
using InkWell.Application.Dtos.Post;
using InkWell.Domain.Utilities.Params;

namespace InkWell.Application.BusinessLogic.Posts.Queries.GetFypPosts;
public sealed record GetFollowingPostsQuery(EntryParams EntryParams) : IQuery<GridDto<ResponsePostDto>>;