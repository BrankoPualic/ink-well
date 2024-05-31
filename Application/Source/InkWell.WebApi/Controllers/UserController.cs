using InkWell.Application.BusinessLogic.Users.Commands.DeleteUser;
using InkWell.Application.BusinessLogic.Users.Commands.Update;
using InkWell.Application.BusinessLogic.Users.Commands.UpdateRoles;
using InkWell.Application.BusinessLogic.Users.Queries.GetAllUsers;
using InkWell.Application.BusinessLogic.Users.Queries.GetAllUsersByAdmin;
using InkWell.Application.BusinessLogic.Users.Queries.GetUserProfile;
using InkWell.Application.Dtos._BaseDto;
using InkWell.Application.Dtos.Role;
using InkWell.Application.Dtos.User;
using InkWell.Common;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Utilities.Params;
using InkWell.WebApi.Controllers._BaseApiController;
using InkWell.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

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

		return this.ReturnResult<GridDto<PersonalInformationsDto>, User>(result);
	}

	[HttpGet]
	public async Task<IActionResult> GetAll([FromQuery] EntryParams entryParams)
	{
		var result = await Mediator.Send(new GetAllUsersQuery(entryParams));

		return this.ReturnResult<GridDto<UserDto>, User>(result);
	}

	[HttpGet("{userId}")]
	public async Task<IActionResult> GetUserProfile([FromRoute] Guid userId)
	{
		var result = await Mediator.Send(new GetUserProfileQuery(userId));

		return this.ReturnResult<ProfileDto, User>(result);
	}

	[HttpDelete("{id}")]
	[Authorize(Policy = Constants.ADMINISTRATOR_USERADMIN)]
	public async Task<IActionResult> Delete([FromRoute] Guid id)
	{
		var result = await Mediator.Send(new DeleteUserCommand(id));

		return this.ReturnResult<User>(result, HttpStatusCode.NoContent);
	}

	[HttpPut("roles/{id}")]
	[Authorize(Policy = Constants.ADMINISTRATOR_USERADMIN)]
	public async Task<IActionResult> UpdateRoles([FromRoute] Guid id, [FromBody] RoleDto roles)
	{
		var result = await Mediator.Send(new UpdateRolesCommand(id, roles));

		return this.ReturnResult<User>(result, HttpStatusCode.NoContent);
	}

	[HttpPut]
	[Authorize]
	public async Task<IActionResult> Update([FromForm] EntryUpdateUserDto userDto)
	{
		var result = await Mediator.Send(new UpdateUserCommand(userDto));

		return this.ReturnResult<User>(result, HttpStatusCode.NoContent);
	}
}