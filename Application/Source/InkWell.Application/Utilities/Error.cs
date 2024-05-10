using FluentValidation.Results;
using Microsoft.AspNetCore.Http;

namespace InkWell.Application.Utilities;
public record Error(string Title, string Message, int Code)
{
	public static readonly Error None = new(string.Empty, string.Empty, default);
	public static readonly Error NullValue = new("Error.NullValue", "Null value was provided", StatusCodes.Status400BadRequest);

	public static readonly Error SaveChangesFailed = new("Error.SaveChangesFailed", "Something went wrong", StatusCodes.Status500InternalServerError);
	public static readonly Error ServerError = new("Error.InternalServerError", "Internal Server Error", StatusCodes.Status500InternalServerError);
	public static readonly Error ActionForbidden = new("Error.Forbidden", "Action forbidden", StatusCodes.Status403Forbidden);
	public static readonly Error Unauthorized = new("Error.Unauthorized", "Unauthorized", StatusCodes.Status401Unauthorized);
	public static readonly Error BadRequest = new("Error.BadRequest", "Bad request", StatusCodes.Status400BadRequest);

	public static readonly Error Inactive = new("Error.Inactive", "Currently unavailable. Please contact administrator.", StatusCodes.Status400BadRequest);

	public static implicit operator Result(Error error) => Result.Failure(error);
}

public sealed record Error<T>(string Title, string Message, int Code)
	: Error(Title, Message, Code)
{
	public static readonly Error<T> NotFound = new($"{typeof(T).Name}.NotFound", $"No {typeof(T).Name.ToLower()} found", StatusCodes.Status404NotFound);
}

public sealed record ValidationError(string Title, string Message, int Code, List<SubError> SubErrors)
	: Error(Title, Message, Code)
{
	public static Result<T> FailureWithValidationResult<T>(ValidationResult validationResult)
	{
		var error = ProcessValidationErrors(validationResult);

		return Result.Failure<T>(error);
	}

	public static Result FailureWithValidationResult(ValidationResult validationResult)
	{
		var error = ProcessValidationErrors(validationResult);

		return Result.Failure(error);
	}

	private static ValidationError ProcessValidationErrors(ValidationResult validationResult)
	{
		var subErrors = validationResult.Errors
					.Select(e => new SubError(e.PropertyName, e.ErrorMessage))
					.ToList();

		var error = new ValidationError("Validation.Error", "Validation failed", StatusCodes.Status403Forbidden, subErrors);
		return error;
	}
}

public sealed record SubError(string Title, string Message);