using AutoMapper;
using FluentValidation;
using InkWell.Application.Dtos._BaseDto;
using InkWell.Domain.Repositories;

namespace InkWell.Application.Abstractions.Messaging;

public abstract class BaseHandler
{
	private readonly IUnitOfWork _unitOfWork;
	private readonly IMapper _mapper;

	protected BaseHandler(IUnitOfWork unitOfWork)
	{
		_unitOfWork = unitOfWork;
	}

	public BaseHandler(IUnitOfWork unitOfWork, IMapper mapper)
	{
		_unitOfWork = unitOfWork;
		_mapper = mapper;
	}

	protected IUnitOfWork UnitOfWork => _unitOfWork;
	protected IMapper Mapper => _mapper;
}

public abstract class BaseHandler<TRequest> : BaseHandler
	where TRequest : BaseDto
{
	private readonly IValidator<TRequest> _validator;

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

	protected IValidator<TRequest> Validator => _validator;
}