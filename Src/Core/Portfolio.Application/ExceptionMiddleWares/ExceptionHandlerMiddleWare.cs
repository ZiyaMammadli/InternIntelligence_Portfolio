using Microsoft.AspNetCore.Http;

namespace Portfolio.Application.ExceptionMiddleWares;

public class ExceptionHandlerMiddleWare : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
		try
		{
			await next(context);
		}
		catch (Exception)
		{

			throw;
		}
    }
}
