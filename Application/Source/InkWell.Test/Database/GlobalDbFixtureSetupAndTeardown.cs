namespace InkWell.Test.Database;

public class GlobalDbFixtureSetupAndTeardown
{
	private static DatabaseFixture _fixture;

	protected static DatabaseFixture Fixture { get => _fixture; }

	[OneTimeSetUp]
	public void GlobalSetup()
	{
		_fixture = new DatabaseFixture();
	}

	[OneTimeTearDown]
	public void GlobalTeardown()
	{
		_fixture.Dispose();
	}
}