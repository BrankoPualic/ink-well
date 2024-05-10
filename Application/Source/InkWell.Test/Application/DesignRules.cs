using FluentAssertions;
using InkWell.Application.Abstractions.Messaging;
using NetArchTest.Rules;

namespace InkWell.Test.Application;

[TestFixture]
public class DesignRules
{
	[Test]
	public void CommandsAndQueriesShouldBeSealed()
	{
		var assembly = typeof(BaseHandler).Assembly;

		var testResult = Types
			.InAssembly(assembly)
			.That()
			.ImplementInterface(typeof(ICommand))
			.Or()
			.ImplementInterface(typeof(ICommand<>))
			.Or()
			.ImplementInterface(typeof(IQuery<>))
			.Should()
			.BeSealed()
			.GetResult();

		testResult.IsSuccessful.Should().BeTrue();
	}
}