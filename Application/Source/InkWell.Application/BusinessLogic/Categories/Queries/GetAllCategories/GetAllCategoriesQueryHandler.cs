using AutoMapper;
using InkWell.Application.Abstractions.Messaging;
using InkWell.Application.Dtos.Category;
using InkWell.Application.Utilities;
using InkWell.Domain.Entities.Application;
using InkWell.Domain.Repositories;

namespace InkWell.Application.BusinessLogic.Categories.Queries.GetAllCategories;

internal class GetAllCategoriesQueryHandler : BaseHandler, IQueryHandler<GetAllCategoriesQuery, IEnumerable<ResponseCategoryDto>>
{
	public GetAllCategoriesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper) : base(unitOfWork, mapper)
	{
	}

	public async Task<Result<IEnumerable<ResponseCategoryDto>>> Handle(GetAllCategoriesQuery request, CancellationToken cancellationToken)
	{
		var categories = await UnitOfWork.CategoryRepository.GetAllCategoriesAsync(cancellationToken);

		if (categories is null)
		{
			return Result.Failure<IEnumerable<ResponseCategoryDto>>(Error<Category>.NotFound);
		}

		var mappedResults = Mapper.Map<IEnumerable<ResponseCategoryDto>>(categories);

		return Result.Success(mappedResults);
	}
}