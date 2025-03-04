using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Portfolio.Application.Bases;
using Portfolio.Application.Behaviours;
using Portfolio.Application.ExceptionMiddleWares;
using Portfolio.Application.Features.Auth.Commands.Login;
using Portfolio.Application.Features.Auth.Rules;
using System.Reflection;

namespace Portfolio.Application;

public static class ApplicationRegistration
{
    public static void AddApplication(this IServiceCollection services)
    {
        Assembly assembly = Assembly.GetExecutingAssembly();
        services.AddTransient<ExceptionHandlerMiddleWare>();
        services.AddMediatR(config => config.RegisterServicesFromAssembly(typeof(LoginCommandHandler).Assembly));
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(FluentValidationBehaviour<,>));
        services.AddValidatorsFromAssemblyContaining(typeof(LoginCommandValidator));
        services.AddRulesFromAssembly(assembly, typeof(BaseRule));
    }

    private static IServiceCollection AddRulesFromAssembly(
        this IServiceCollection services,
        Assembly assembly,
        Type type)
    {
        var types = assembly.GetTypes().Where(t=>t.IsSubclassOf(type) && type !=t).ToList();
        foreach (var item in types)
        {
            services.AddTransient(item);
        }
        return services;
    }

}
