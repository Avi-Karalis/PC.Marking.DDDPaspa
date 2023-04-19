using Microsoft.Extensions.DependencyInjection;

namespace Application.DependencyResolver;
public static class ServiceCollectionExtensions {

    public static IServiceCollection AddApplication(this IServiceCollection services) {

        var assembly = typeof(ServiceCollectionExtensions).Assembly;
        // Add all application-specific services to the service collection
        services.AddDomain();
        services.AddScoped<Marking>();
        services.AddScoped<IQuestionMarkingBase, QuestionMarkingBase>();
        services.AddScoped<IExamMarkingBase, ExamMarkingBase>();
        services.AddScoped<ISectionMarkingBase, SectionMarkingBase>();
        services.AddMediatR(configuration =>
            configuration.RegisterServicesFromAssembly(assembly)
            );
        return services;

    }

}
