using InkWell.Application.BusinessLogic.Likes.Commands.LikePost;
using InkWell.Application.BusinessLogic.Likes.Commands.RemoveLike;
using InkWell.Application.Dtos.Like;
using InkWell.Domain.Entities.Application;
using InkWell.WebApi.Controllers._BaseApiController;
using InkWell.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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

		if (result.IsSuccess)
		{
			return Created();
		}

		return this.HandleErrorResponse<Post>(result.Error);
	}

	[HttpDelete("{postId}")]
	public async Task<IActionResult> RemoveLike([FromRoute] Guid postId)
	{
		var result = await Mediator.Send(new RemoveLikeCommand(postId));

		if (result.IsSuccess)
		{
			return NoContent();
		}

		return this.HandleErrorResponse<Like>(result.Error);
	}
}