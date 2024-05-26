using InkWell.Application.BusinessLogic.Categories.Queries.GetAllCategories;
using InkWell.Domain.Entities.Application;
using InkWell.WebApi.Controllers._BaseApiController;
using InkWell.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace InkWell.WebApi.Controllers;

public class CategoryController : BaseApiController
{
	public CategoryController(IMediator mediator) : base(mediator)
	{
	}

	[HttpGet]
	public async Task<IActionResult> GetCategories()
	{
		var result = await Mediator.Send(new GetAllCategoriesQuery());

		if (result.IsSuccess)
		{
			return Ok(result.Value);
		}

		return this.HandleErrorResponse<Category>(result.Error);
	}
}