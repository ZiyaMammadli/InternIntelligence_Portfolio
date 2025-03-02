using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Application.Behaviours;
using Portfolio.Application.ExceptionMiddleWares;
using Portfolio.Application.Features.Auth.Commands.Login;

namespace Portfolio.Application;

public static class ApplicationRegistration
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddTransient<ExceptionHandlerMiddleWare>();
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehaviour<,>));
        services.AddValidatorsFromAssemblyContaining(typeof(LoginCommandValidator));
    }
}
