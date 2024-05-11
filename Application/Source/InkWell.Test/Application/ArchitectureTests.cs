using FluentAssertions;
using NetArchTest.Rules;

namespace InkWell.Test.Application;

[TestFixture]
public class ArchitectureTests
{
	private const string ApplicationNamespace = "Application";
	private const string InfrastructureNamespace = "Infrastructure";
	private const string PersistenceNamespace = "Persistence";
	private const string WebApiNamespace = "WebApi";

	[Test]
	public void DomainShouldNotHaveDependencyOnOtherLayers()
	{
		var assembly = typeof(Domain.Entities.Application.User).Assembly;

		var otherLayers = new[]
		{
			ApplicationNamespace,
			InfrastructureNamespace,
			PersistenceNamespace,
			WebApiNamespace,
		};

		var testResult = Types
			.InAssembly(assembly)
			.ShouldNot()
			.HaveDependencyOnAll(otherLayers)
			.GetResult();

		testResult.IsSuccessful.Should().BeTrue();
	}

	[Test]
	public void ApplicationShouldNotHaveDependencyOnOtherLayers()
	{
		var assembly = typeof(InkWell.Application.Abstractions.Messaging.BaseHandler).Assembly;

		var otherLayers = new[]
		{
			InfrastructureNamespace,
			PersistenceNamespace,
			WebApiNamespace,
		};

		var testResult = Types
			.InAssembly(assembly)
			.ShouldNot()
			.HaveDependencyOnAll(otherLayers)
			.GetResult();

		testResult.IsSuccessful.Should().BeTrue();
	}

	[Test]
	public void InfrastructureShouldNotHaveDependencyOnOtherLayers()
	{
		var assembly = typeof(Infrastructure.Logger.ConsoleExceptionLogger).Assembly;

		var otherLayers = new[]
		{
			PersistenceNamespace,
			WebApiNamespace,
		};

		var testResult = Types
			.InAssembly(assembly)
			.ShouldNot()
			.HaveDependencyOnAll(otherLayers)
			.GetResult();

		testResult.IsSuccessful.Should().BeTrue();
	}

	[Test]
	public void PersistenceShouldNotHaveDependencyOnOtherLayers()
	{
		var assembly = typeof(Persistence.Contexts.InkWellContext).Assembly;

		var otherLayers = new[]
		{
			InfrastructureNamespace,
			WebApiNamespace,
		};

		var testResult = Types
			.InAssembly(assembly)
			.ShouldNot()
			.HaveDependencyOnAll(otherLayers)
			.GetResult();

		testResult.IsSuccessful.Should().BeTrue();
	}
}