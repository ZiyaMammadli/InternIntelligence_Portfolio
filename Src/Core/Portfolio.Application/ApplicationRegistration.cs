using Microsoft.Extensions.DependencyInjection;
using Portfolio.Application.ExceptionMiddleWares;

namespace Portfolio.Application;

public static class ApplicationRegistration
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddTransient<ExceptionHandlerMiddleWare>();
    }
}
