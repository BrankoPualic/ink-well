using InkWell.Application.BusinessLogic.Comments.Commands.CreateComment;
using InkWell.Application.BusinessLogic.Comments.Commands.DeleteComment;
using InkWell.Application.BusinessLogic.Comments.Queries.GetAllPostComments;
using InkWell.Application.BusinessLogic.Comments.Queries.GetAllUserComments;
using InkWell.Application.Dtos._BaseDto;
using InkWell.Application.Dtos.Comment;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Utilities.Params;
using InkWell.WebApi.Controllers._BaseApiController;
using InkWell.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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

		return this.ReturnResult<GridDto<ResponseCommentDto>, Comment>(result);
	}

	[HttpGet("user-comments")]
	[Authorize]
	public async Task<IActionResult> GetAllUserComments([FromQuery] EntryParams entryParams)
	{
		var result = await Mediator.Send(new GetAllUserCommentsQuery(entryParams));

		return this.ReturnResult<GridDto<ResponseCommentDto>, Comment>(result);
	}

	[HttpPost]
	[Authorize]
	public async Task<IActionResult> CreateComment([FromBody] EntryCommentDto comment)
	{
		var result = await Mediator.Send(new CreateCommentCommand(comment));

		return this.ReturnResult<Comment>(result, HttpStatusCode.Created);
	}

	[HttpDelete("{commentId}")]
	[Authorize]
	public async Task<IActionResult> DeleteComment([FromRoute] Guid commentId)
	{
		var result = await Mediator.Send(new DeleteCommentCommand(commentId));

		return this.ReturnResult<Comment>(result, HttpStatusCode.NoContent);
	}
}