using InkWell.Application.BusinessLogic.Posts.Commands.DeletePost;
using InkWell.Application.BusinessLogic.Posts.Queries.GetAllPosts;
using InkWell.Common;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Utilities.Params;
using InkWell.WebApi.Controllers._BaseApiController;
using InkWell.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InkWell.WebApi.Controllers;

public class PostController : BaseApiController
{
	public PostController(IMediator mediator) : base(mediator)
	{
	}

	[HttpGet]
	public async Task<IActionResult> GetAll([FromQuery] EntryParams entryParams, [FromQuery] Guid? categoryId)
	{
		var result = await Mediator.Send(new GetAllPostsQuery(entryParams, categoryId));

		if (result.IsSuccess)
		{
			return Ok(result.Value);
		}

		return this.HandleErrorResponse<Post>(result.Error);
	}

	[HttpDelete("{id}")]
	[Authorize(Policy = Constants.ADMINISTRATOR_MODERATOR_BLOGGER)]
	public async Task<IActionResult> DeletePost([FromRoute] Guid id)
	{
		var result = await Mediator.Send(new DeletePostCommand(id));

		if (result.IsSuccess)
		{
			return NoContent();
		}

		return this.HandleErrorResponse<Post>(result.Error);
	}
}