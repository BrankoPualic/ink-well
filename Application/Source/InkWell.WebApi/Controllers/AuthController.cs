using InkWell.Application.BusinessLogic.Users.Commands.Signup;
using InkWell.Application.Dtos.User;
using InkWell.Domain.Entities.Application;
using InkWell.WebApi.Controllers._BaseApiController;
using InkWell.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InkWell.WebApi.Controllers;

public class AuthController : BaseApiController
{
	public AuthController(IMediator mediator) : base(mediator)
	{
	}

	[HttpPost("signup")]
	public async Task<IActionResult> Signup([FromForm] SignupDto user)
	{
		var result = await Mediator.Send(new SignupCommand(user));

		if (result.IsSuccess)
		{
			return Ok(result.Value);
		}

		return this.HandleErrorResponse<User>(result.Error);
	}
}