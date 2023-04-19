using Domain.DependencyResolver;
using Microsoft.Extensions.DependencyInjection;
using RepoInterfaces;

namespace Infrastructure.DependencyResolver;
public static class ServiceCollectionExtensions {

    // Adds the DatabaseContext to the service collection
    public static IServiceCollection AddInfrastructure (this IServiceCollection services) {
        services.AddDatabaseContext();

        // Registers the ExamRepository, SectionRepository, and QuestionRepository with scoped lifetime
        services.AddScoped<IExamRepository, ExamRepository>();
        services.AddScoped<ISectionRepository, SectionRepository>();
        services.AddScoped<IQuestionRepository, QuestionRepository>();
        // Returns the modified service collection
        return services;

    }

}
