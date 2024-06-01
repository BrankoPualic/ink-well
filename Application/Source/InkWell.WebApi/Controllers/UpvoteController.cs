using InkWell.Application.BusinessLogic.Upvotes.Commands.RemoveUpvote;
using InkWell.Application.BusinessLogic.Upvotes.Commands.SetUpvote;
using InkWell.Application.Dtos.Upvote;
using InkWell.Domain.Entities.Application;
using InkWell.WebApi.Controllers._BaseApiController;
using InkWell.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InkWell.WebApi.Controllers;

[Authorize]
public class UpvoteController : BaseApiController
{
	public UpvoteController(IMediator mediator) : base(mediator)
	{
	}

	[HttpPost]
	public async Task<IActionResult> SetUpvote([FromBody] EntryUpvoteDto upvote)
	{
		var result = await Mediator.Send(new SetUpvoteCommand(upvote));

		return this.ReturnResult<Comment>(result, HttpStatusCode.Created);
	}

	[HttpDelete("{commentId}")]
	public async Task<IActionResult> RemoveUpvote([FromRoute] Guid commentId)
	{
		var result = await Mediator.Send(new RemoveUpvoteCommand(commentId));

		return this.ReturnResult<Upvote>(result, HttpStatusCode.NoContent);
	}
}