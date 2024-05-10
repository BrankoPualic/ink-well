using AutoMapper;
using FluentValidation;
using InkWell.Application.Dtos.BaseDto;
using InkWell.Domain.Repositories;

namespace InkWell.Application.Abstractions.Messaging;

public class BaseHandler
{
	protected readonly IUnitOfWork _unitOfWork;
	protected readonly IMapper _mapper;

	protected BaseHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public BaseHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}
}

public class BaseHandler<TRequest> : BaseHandler
	where TRequest : BaseDto
{
	protected readonly IValidator<TRequest> _validator;

	public BaseHandler(IUnitOfWork unitOfWork) : base(unitOfWork)
	{
	}

	public BaseHandler(IUnitOfWork unitOfWork, IValidator<TRequest> validator)
		: this(unitOfWork)
	{
		_validator = validator;
	}

	public BaseHandler(IUnitOfWork unitOfWork, IMapper mapper, IValidator<TRequest> validator)
		: base(unitOfWork, mapper)
	{
		_validator = validator;
	}
}