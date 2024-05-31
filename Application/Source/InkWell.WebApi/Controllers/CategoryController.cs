using InkWell.Application.BusinessLogic.Categories.Commands.AddCategory;
using InkWell.Application.BusinessLogic.Categories.Commands.DeleteCategory;
using InkWell.Application.BusinessLogic.Categories.Commands.UpdateCategory;
using InkWell.Application.BusinessLogic.Categories.Queries.GetAllCategories;
using InkWell.Application.Dtos.Category;
using InkWell.Common;
using InkWell.Domain.Entities.Application;
using InkWell.WebApi.Controllers._BaseApiController;
using InkWell.WebApi.Extensions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace InkWell.WebApi.Controllers;

[Authorize(Policy = Constants.ADMINISTRATOR_USERADMIN_MODERATOR)]
public class CategoryController : BaseApiController
{
	public CategoryController(IMediator mediator) : base(mediator)
	{
	}

	[HttpGet]
	[AllowAnonymous]
	public async Task<IActionResult> GetCategories()
	{
		var result = await Mediator.Send(new GetAllCategoriesQuery());

		return this.ReturnResult<IEnumerable<ResponseCategoryDto>, Category>(result);
	}

	[HttpPost]
	public async Task<IActionResult> AddCategory([FromBody] EntryCategoryDto category)
	{
		var result = await Mediator.Send(new AddCategoryCommand(category));

		return this.ReturnResult<Category>(result, HttpStatusCode.Created);
	}

	[HttpDelete("{id}")]
	public async Task<IActionResult> DeleteCategory([FromRoute] Guid id)
	{
		var result = await Mediator.Send(new DeleteCategoryCommand(id));

		return this.ReturnResult<Category>(result, HttpStatusCode.NoContent);
	}

	[HttpPut("{id}")]
	public async Task<IActionResult> UpdateCategory([FromRoute] Guid id, [FromBody] EntryUpdateCategoryDto category)
	{
		var result = await Mediator.Send(new UpdateCategoryCommand(id, category));

		return this.ReturnResult<Category>(result, HttpStatusCode.NoContent);
	}
}