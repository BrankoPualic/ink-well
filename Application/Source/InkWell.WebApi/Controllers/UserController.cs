using InkWell.Application.BusinessLogic.Users.Queries.GetAllUsers;
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

	[HttpGet]
	[Authorize(Policy = Constants.ADMINISTRATOR_USERADMIN)]
	public async Task<IActionResult> GetAllAsync([FromQuery] EntryParams entryParams)
	{
		var result = await Mediator.Send(new GetAllUsersQuery(entryParams));

		if (result.IsSuccess)
		{
			return Ok(result.Value);
		}

		return this.HandleErrorResponse<User>(result.Error);
	}
}