using FluentAssertions;
using InkWell.Application.Abstractions.Messaging;
using NetArchTest.Rules;

namespace InkWell.Test.Application;

[TestFixture]
public class NamingConventions
{
	[Test]
	public void CommandHandlerShouldHaveNameEndingWithCommandHandler()
	{
		var assembly = typeof(BaseHandler).Assembly;

		var testResult = Types
			.InAssembly(assembly)
			.That()
			.ImplementInterface(typeof(ICommandHandler<>))
			.Should()
			.HaveNameEndingWith("CommandHandler")
			.GetResult();

		testResult.IsSuccessful.Should().BeTrue();
	}
}