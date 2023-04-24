using Domain.DependencyResolver;
using Application.DependencyResolver;
using Microsoft.Extensions.DependencyInjection;
using RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DependencyResolver {
    public static class ServiceCollectionExtensions {

        // Adds the DatabaseContext to the service collection
        public static IServiceCollection AddInfrastructure (this IServiceCollection services) {
            services.AddDatabaseContext();

            // Registers the ExamRepository, SectionRepository, and QuestionRepository with scoped lifetime
            
            // replace the following two lines with an ExamService
            services.AddScoped<IExamRepository, ExamRepository>();
            services.AddScoped<IExamRepository, ExamRepository2>();
            services.AddScoped<IExamService, ExamService>();

            //salalalalalaal


            //services.AddScoped(typeof(ExamRepository2)) === services.AddScoped<ExamRepository2>();
            services.AddScoped<ISectionRepository, SectionRepository>();
            services.AddScoped<IQuestionRepository, QuestionRepository>();
            // Returns the modified service collection
            return services;

        }

    }
}
