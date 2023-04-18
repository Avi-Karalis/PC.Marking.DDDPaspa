using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application.DependencyResolver;

public static class ServiceCollectionExtensions {

    // Declare a public static method called "AddDomain" which extends the "IServiceCollection" interface
    public static void AddDomain(this IServiceCollection services) {
        // Adds all validators found in the same assembly as the executing code to the service collection
        services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

    }

}
