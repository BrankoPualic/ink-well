using FluentAssertions;
using InkWell.Domain.Interfaces;
using InkWell.Infrastructure.Logger;
using InkWell.Persistence.Repositories;
using InkWell.Test.Database;
using InkWell.WebApi.Middlewares;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Hosting;
using Moq;

namespace InkWell.Test.Middlewares;

[TestFixture]
public class ExceptionMiddlewareTests : GlobalDbFixtureSetupAndTeardown
{
	[Test]
	public async Task MiddlewareCatchesException_AndLogError()
	{
		var mockLogger = new Mock<IExceptionLogger>();
		var mockEnv = new Mock<IHostEnvironment>();
		var middleware = new ExceptionMiddleware(
			(context) => Task.CompletedTask,
			mockLogger.Object,
			mockEnv.Object);

		var mockHttpContext = new DefaultHttpContext();

		RequestDelegate next = (ctx) =>
		{
			throw new InvalidOperationException("Test exception");
		};

		await middleware.InvokeAsync(mockHttpContext, next);

		mockLogger.Verify(logger => logger.LogException(It.IsAny<Exception>()), Times.Once);
	}

	[Test]
	public void LogExceptionShould_LogErrorIntoTestDatabase()
	{
		var unitOfWork = new UnitOfWork(Fixture.Context);
		var logger = new DbExceptionLogger(unitOfWork);

		var exceptionId = logger.LogException(new Exception("Test exception"));

		var error = Fixture.Context.ErrorLogs.SingleOrDefault(e => e.ErrorId == exceptionId);

		error.Should().NotBeNull();
		error.Message.Should().Be("Test exception");
		error.Time.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromSeconds(500));
	}
}