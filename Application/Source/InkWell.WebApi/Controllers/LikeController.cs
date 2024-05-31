using InkWell.Application.BusinessLogic.Likes.Commands.LikePost;
using InkWell.Application.BusinessLogic.Likes.Commands.RemoveLike;
using InkWell.Application.Dtos.Like;
using InkWell.Domain.Entities.Application;
using InkWell.WebApi.Controllers._BaseApiController;
using InkWell.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InkWell.WebApi.Controllers;

[Authorize]
public class LikeController : BaseApiController
{
	public LikeController(IMediator mediator) : base(mediator)
	{
	}

	[HttpPost]
	public async Task<IActionResult> LikePost([FromBody] LikeDto like)
	{
		var result = await Mediator.Send(new LikePostCommand(like));

		return this.ReturnResult<Post>(result, HttpStatusCode.Created);
	}

	[HttpDelete("{postId}")]
	public async Task<IActionResult> RemoveLike([FromRoute] Guid postId)
	{
		var result = await Mediator.Send(new RemoveLikeCommand(postId));

		return this.ReturnResult<Like>(result, HttpStatusCode.NoContent);
	}
}