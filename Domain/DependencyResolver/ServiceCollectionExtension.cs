using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.DependencyResolver;

public static class ServiceCollectionExtensions {

    public static void AddDomain(this IServiceCollection services) {

        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

    }

}
