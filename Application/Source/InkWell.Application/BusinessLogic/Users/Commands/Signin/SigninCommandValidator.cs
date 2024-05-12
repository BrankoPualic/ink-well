using FluentValidation;
using InkWell.Application.Dtos.User;
using InkWell.Domain.Repositories;

namespace InkWell.Application.BusinessLogic.Users.Commands.Signin;

public class SigninCommandValidator : AbstractValidator<SigninDto>
{
	public SigninCommandValidator(IUnitOfWork unitOfWork)
	{
		RuleFor(u => u.Email)
			.NotEmpty().WithMessage("Email is required.")
			.EmailAddress().WithMessage("Invalid email format.")
			.MustAsync(unitOfWork.UserRepository.UserExistByEmailAsync).WithMessage("User doesn't exist.")
			.MaximumLength(60).WithMessage("Email can't be longer than 60 characters.");

		RuleFor(x => x.Password)
			.NotEmpty().WithMessage("Password is required.")
			.MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
			.Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
			.Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
			.Matches("[0-9]").WithMessage("Password must contain at least one digit.")
			.Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");
	}
}