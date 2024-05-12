using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InkWell.WebApi.Controllers._BaseApiController;

[Route("api/[controller]")]
[ApiController]
public abstract class BaseApiController : ControllerBase
{
	private readonly IMediator _mediator;

	public BaseApiController(IMediator mediator)
	{
		_mediator = mediator;
	}

	protected IMediator Mediator => _mediator;
}