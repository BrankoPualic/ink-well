using InkWell.Application.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace InkWell.WebApi.Extensions;

public static class ControllerExtensions
{
	public static IActionResult HandleErrorResponse<T>(this ControllerBase controller, Result result)
	{
		if (result.Error == Error<T>.NotFound)
		{
			return controller.NotFound(result.Error);
		}

		if (result.Error == Error.SaveChangesFailed
			|| result.Error == Error.ServerError)
		{
			return controller.StatusCode(500, result.Error);
		}

		if (result.Error is ValidationError)
		{
			return controller.UnprocessableEntity(result.Error);
		}

		if (result.Error == Error.ActionForbidden)
		{
			return controller.StatusCode(403, result.Error);
		}

		return controller.BadRequest(result.Error);
	}
}