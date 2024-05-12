using FluentValidation;
using InkWell.Application.Dtos.User;
using InkWell.Domain.Repositories;

namespace InkWell.Application.BusinessLogic.Users.Commands.Signup;

public class SignupCommandValidator : AbstractValidator<SignupDto>
{
	public SignupCommandValidator(IUnitOfWork unitOfWork)
	{
		RuleFor(u => u.FirstName)
				.NotEmpty().WithMessage("First name is required.")
				.Length(3, 20).WithMessage("First name must be between 3 and 30 characters.");

		RuleFor(u => u.LastName)
			.NotEmpty().WithMessage("Last name is required.")
			.Length(3, 50).WithMessage("Last name must be between 3 and 50 characters.");

		RuleFor(u => u.Email)
			.NotEmpty().WithMessage("Email is required.")
			.EmailAddress().WithMessage("Invalid email format.")
			.MustAsync(async (email, cancellationToken) =>
			{
				return !await unitOfWork.UserRepository.UserExistByEmailAsync(email, cancellationToken);
			}).WithMessage("Account with this email already exist.")
			.MaximumLength(60).WithMessage("Email can't be longer than 60 characters.");

		RuleFor(u => u.Username)
			.NotEmpty().WithMessage("Username is required.")
			.Length(4, 20).WithMessage("Username must be between 4 and 20 cahracters.")
			.MustAsync(async (username, cancellationToken) =>
			{
				return !await unitOfWork.UserRepository.UserExistByUsernameAsync(username, cancellationToken);
			}).WithMessage("Username already in use.");

		RuleFor(u => u.Password)
			.NotEmpty().WithMessage("Password is required.")
			.MinimumLength(8).WithMessage("Password must be at least 8 characters long.")
			.Matches("[A-Z]").WithMessage("Password must contain at least one uppercase letter.")
			.Matches("[a-z]").WithMessage("Password must contain at least one lowercase letter.")
			.Matches("[0-9]").WithMessage("Password must contain at least one digit.")
			.Matches("[^a-zA-Z0-9]").WithMessage("Password must contain at least one special character.");

		RuleFor(u => u.ConfirmPassword)
			.NotEmpty().WithMessage("Confirm password is required.")
			.Equal(u => u.Password).WithMessage("Confirm password and password do not match.");

		RuleFor(u => u.DateOfBirth)
			.NotEmpty().WithMessage("Date of birth is required.")
			.Must(BeAtLeastTenYearsOld).WithMessage("User must be at least 10 years old.");
	}

	private bool BeAtLeastTenYearsOld(DateOnly dob)
	{
		DateOnly minimumDob = DateOnly.FromDateTime(DateTime.Today.AddYears(-10));
		return dob <= minimumDob;
	}
}