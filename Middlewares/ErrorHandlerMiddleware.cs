﻿namespace SteganographyWebApp.Middlewares
{
	public class ErrorHandlerMiddleware : IMiddleware
	{
		public async Task InvokeAsync(HttpContext context, RequestDelegate next)
		{
			try
			{
				await next.Invoke(context);
			}
			catch
			{
				context.Response.StatusCode = 500;
				await context.Response.WriteAsync("Something went wrong.");
			}
		}
	}
}
