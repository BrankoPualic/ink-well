using InkWell.Application.BusinessLogic.Users.Commands.DeleteUser;
using InkWell.Application.BusinessLogic.Users.Queries.GetAllUsers;
using InkWell.Application.BusinessLogic.Users.Queries.GetAllUsersByAdmin;
using InkWell.Common;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Utilities.Params;
using InkWell.WebApi.Controllers._BaseApiController;
using InkWell.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InkWell.WebApi.Controllers;

public class UserController : BaseApiController
{
	public UserController(IMediator mediator) : base(mediator)
	{
	}

	[HttpGet("detailed")]
	[Authorize(Policy = Constants.ADMINISTRATOR_USERADMIN)]
	public async Task<IActionResult> GetAllByAdmin([FromQuery] EntryParams entryParams)
	{
		var result = await Mediator.Send(new GetAllUsersByAdminQuery(entryParams));

		if (result.IsSuccess)
		{
			return Ok(result.Value);
		}

		return this.HandleErrorResponse<User>(result.Error);
	}

	[HttpGet]
	public async Task<IActionResult> GetAll([FromQuery] EntryParams entryParams)
	{
		var result = await Mediator.Send(new GetAllUsersQuery(entryParams));

		if (result.IsSuccess)
		{
			return Ok(result.Value);
		}

		return this.HandleErrorResponse<User>(result.Error);
	}

	[HttpDelete("{id}")]
	[Authorize(Policy = Constants.ADMINISTRATOR_USERADMIN)]
	public async Task<IActionResult> Delete([FromRoute] Guid id)
	{
		var result = await Mediator.Send(new DeleteUserCommand(id));

		if (result.IsSuccess)
		{
			return NoContent();
		}

		return this.HandleErrorResponse<User>(result.Error);
	}
}