using Microsoft.AspNetCore.Builder;

namespace Portfolio.Application.ExceptionMiddleWares;

public static class ExceptionMiddleWare
{
    public static void UseExceptionMiddleWare(this IApplicationBuilder app)
    {
        app.UseMiddleware<ExceptionHandlerMiddleWare>();
    }
}
