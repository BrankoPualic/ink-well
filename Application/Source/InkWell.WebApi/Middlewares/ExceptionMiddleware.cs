using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Net;
using InkWell.Application.Utilities;
using InkWell.Domain.Interfaces;

namespace InkWell.WebApi.Middlewares;

public class ExceptionMiddleware
{
	private readonly RequestDelegate _next;
	private readonly IHostEnvironment _env;

	public ExceptionMiddleware(RequestDelegate next, IHostEnvironment env)
	{
		_next = next;
		_env = env;
	}

	public async Task InvokeAsync(HttpContext context, IExceptionLogger logger)
	{
		try
		{
			await _next(context);
		}
		catch (Exception ex)
		{
			await HandleExceptionAsync(context, ex, logger, _env);
		}

		if (context.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
		{
			await HandleUnauthorizedAsync(context);
		}
	}

	public async Task InvokeAsyncTest(HttpContext context, RequestDelegate next, IExceptionLogger logger)
	{
		try
		{
			await next(context);
		}
		catch (Exception ex)
		{
			await HandleExceptionAsync(context, ex, logger, _env);
		}

		if (context.Response.StatusCode == (int)HttpStatusCode.Unauthorized)
		{
			await HandleUnauthorizedAsync(context);
		}
	}

	private static Task HandleExceptionAsync(HttpContext context, Exception ex, IExceptionLogger logger, IHostEnvironment env)
	{
		logger.LogException(ex);
		context.Response.ContentType = "application/json";

		var response = env.IsDevelopment()
			? new Error("Error.ServerError", $"{ex.Message}\n{ex.StackTrace}", StatusCodes.Status500InternalServerError)
			: Error.ServerError;

		var settings = new JsonSerializerSettings
		{
			ContractResolver = new CamelCasePropertyNamesContractResolver(),
			Formatting = Formatting.Indented,
		};
		var json = JsonConvert.SerializeObject(response, settings);

		return context.Response.WriteAsync(json);
	}

	private static Task HandleUnauthorizedAsync(HttpContext context)
	{
		context.Response.ContentType = "application/json";

		var response = Error.Unauthorized;

		var settings = new JsonSerializerSettings
		{
			ContractResolver = new CamelCasePropertyNamesContractResolver(),
			Formatting = Formatting.Indented,
		};

		var json = JsonConvert.SerializeObject(response, settings);

		return context.Response.WriteAsync(json);
	}
}