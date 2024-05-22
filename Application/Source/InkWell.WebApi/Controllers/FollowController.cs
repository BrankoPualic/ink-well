using InkWell.Application.BusinessLogic.Follows.Commands.FollowUser;
using InkWell.Application.BusinessLogic.Follows.Commands.UnfollowUser;
using InkWell.Application.Dtos.Follow;
using InkWell.Domain.Entities.Application;
using InkWell.WebApi.Controllers._BaseApiController;
using InkWell.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InkWell.WebApi.Controllers;

[Authorize]
public class FollowController : BaseApiController
{
	public FollowController(IMediator mediator) : base(mediator)
	{
	}

	[HttpPost]
	public async Task<IActionResult> Follow([FromBody] FollowDto follow)
	{
		var result = await Mediator.Send(new FollowUserCommand(follow));

		if (result.IsSuccess)
		{
			return Created();
		}

		return this.HandleErrorResponse<User>(result.Error);
	}

	[HttpDelete("{followingId}")]
	public async Task<IActionResult> Unfollow([FromRoute] Guid followingId)
	{
		var result = await Mediator.Send(new UnfollowUserCommand(followingId));

		if (result.IsSuccess)
		{
			return NoContent();
		}

		return this.HandleErrorResponse<Follow>(result.Error);
	}
}