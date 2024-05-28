using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos.Post;

namespace InkWell.Application.BusinessLogic.Posts.Queries.GetPost;
public sealed record GetPostQuery(Guid PostId) : IQuery<ResponsePostDto>;