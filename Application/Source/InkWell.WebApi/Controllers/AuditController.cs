using InkWell.Application.BusinessLogic.Audits.Queries.GetAllAudits;
using InkWell.Common;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Utilities.Filters;
using InkWell.Domain.Utilities.Params;
using InkWell.WebApi.Controllers._BaseApiController;
using InkWell.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InkWell.WebApi.Controllers;

[Authorize(Policy = Constants.ADMINISTRATOR_USERADMIN)]
public class AuditController : BaseApiController
{
	public AuditController(IMediator mediator) : base(mediator)
	{
	}

	[HttpGet]
	public async Task<IActionResult> GetAllAudits([FromQuery] EntryParams entryParams, [FromQuery] EntryAuditFilters filters)
	{
		var result = await Mediator.Send(new GetAllAuditsQuery(filters, entryParams));

		if (result.IsSuccess)
		{
			return Ok(result.Value);
		}

		return this.HandleErrorResponse<Audit>(result.Error);
	}
}