using FluentValidation;
using InkWell.Application.Dtos.User;

namespace InkWell.Application.BusinessLogic.Users.Commands.Update;

public class UpdateUserCommandValidator : AbstractValidator<EntryUpdateUserDto>
{
	public UpdateUserCommandValidator()
	{
		RuleFor(x => x.FirstName)
			.NotEmpty().WithMessage("First name is required.")
			.MaximumLength(20).WithMessage("First name can't be longer than 20 characters.")
			.MinimumLength(3).WithMessage("First name can't be less than 3 characters.");

		RuleFor(x => x.LastName)
			.NotEmpty().WithMessage("Last name is required.")
			.MaximumLength(30).WithMessage("Last name can't be longer than 30 characters.")
			.MinimumLength(3).WithMessage("Last name can't be less than 3 characters.");

		RuleFor(x => x.DateOfBirth)
			.NotEmpty().WithMessage("Date of birth is required.")
			.Must(BeAtLeastTenYearsOld).WithMessage("User must be at least 10 years old.");
	}

	private bool BeAtLeastTenYearsOld(DateOnly dob)
	{
		DateOnly minimumDob = DateOnly.FromDateTime(DateTime.Today.AddYears(-10));
		return dob <= minimumDob;
	}
}