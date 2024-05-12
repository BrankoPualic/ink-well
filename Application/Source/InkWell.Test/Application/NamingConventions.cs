using FluentAssertions;
using FluentValidation;
using InkWell.Application.Abstractions.Messaging;
using NetArchTest.Rules;

namespace InkWell.Test.Application;

[TestFixture]
public class NamingConventions
{
	[Test]
	public void CommandHandler_Should_HaveNameEndingWith_CommandHandler()
	{
		var assembly = typeof(BaseHandler).Assembly;

		var testResult = Types
			.InAssembly(assembly)
			.That()
			.ImplementInterface(typeof(ICommandHandler<>))
			.Or()
			.ImplementInterface(typeof(ICommandHandler<,>))
			.Should()
			.HaveNameEndingWith("CommandHandler")
			.GetResult();

		testResult.IsSuccessful.Should().BeTrue();
	}

	[Test]
	public void QueryHandler_Should_HaveNameEndingWith_QueryHandler()
	{
		var assembly = typeof(BaseHandler).Assembly;

		var testResult = Types
			.InAssembly(assembly)
			.That()
			.ImplementInterface(typeof(IQueryHandler<,>))
			.Should()
			.HaveNameEndingWith("QueryHandler")
			.GetResult();

		testResult.IsSuccessful.Should().BeTrue();
	}

	[Test]
	public void Validators_Should_HaveNameEndingWith_Validator()
	{
		var assembly = typeof(BaseHandler).Assembly;

		var testResult = Types
			.InAssembly(assembly)
			.That()
			.Inherit(typeof(AbstractValidator<>))
			.Should()
			.HaveNameEndingWith("Validator")
			.GetResult();

		testResult.IsSuccessful.Should().BeTrue();
	}
}