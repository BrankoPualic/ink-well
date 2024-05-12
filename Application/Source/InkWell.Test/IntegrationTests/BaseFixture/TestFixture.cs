using Microsoft.AspNetCore.Mvc.Testing;

namespace InkWell.Test.IntegrationTests.BaseFixture;

public class TestFixture
{
	private WebApplicationFactory<Program> _factory;

	protected WebApplicationFactory<Program> Factory => _factory;

	[OneTimeSetUp]
	public virtual void SetUp()
	{
		_factory = new WebApplicationFactory<Program>();
	}

	[OneTimeTearDown]
	public virtual void TearDown()
	{
		_factory.Dispose();
	}
}