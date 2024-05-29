using InkWell.Application.BusinessLogic.Comments.Commands.CreateComment;
using InkWell.Application.BusinessLogic.Comments.Queries.GetAllPostComments;
using InkWell.Application.Dtos.Comment;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Utilities.Params;
using InkWell.WebApi.Controllers._BaseApiController;
using InkWell.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InkWell.WebApi.Controllers;

public class CommentController : BaseApiController
{
	public CommentController(IMediator mediator) : base(mediator)
	{
	}

	[HttpGet("{postId}")]
	public async Task<IActionResult> GetAllPostComments([FromQuery] EntryParams entryParams, [FromRoute] Guid postId)
	{
		var result = await Mediator.Send(new GetAllPostCommentsQuery(entryParams, postId));

		if (result.IsSuccess)
		{
			return Ok(result.Value);
		}

		return this.HandleErrorResponse<Comment>(result.Error);
	}

	[HttpPost]
	[Authorize]
	public async Task<IActionResult> CreateComment([FromBody] EntryCommentDto comment)
	{
		var result = await Mediator.Send(new CreateCommentCommand(comment));

		if (result.IsSuccess)
		{
			return Created();
		}

		return this.HandleErrorResponse<Comment>(result.Error);
	}
}