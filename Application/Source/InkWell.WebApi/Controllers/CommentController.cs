using InkWell.Application.BusinessLogic.Comments.Commands.CreateComment;
using InkWell.Application.Dtos.Comment;
using InkWell.Domain.Entities.Application;
using InkWell.WebApi.Controllers._BaseApiController;
using InkWell.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InkWell.WebApi.Controllers;

[Authorize]
public class CommentController : BaseApiController
{
	public CommentController(IMediator mediator) : base(mediator)
	{
	}

	[HttpPost]
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