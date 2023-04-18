using Microsoft.Extensions.DependencyInjection;
using RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DependencyResolver {
    public static class ServiceCollectionExtensions {

        // Declare a public static method called "AddApplication" that extends IServiceCollection and takes an IServiceCollection object as input
        public static IServiceCollection AddApplication(this IServiceCollection services) {

            // Add all application-specific services to the service collection

            services.AddDomain();   // Adds all validators found in the same assembly as the executing code to the service collection

            services.AddScoped<Marking>();  // Adds a scoped service for the "Marking" class

            services.AddScoped<IQuestionMarkingBase, QuestionMarkingBase>();    // Adds a scoped service for the "IQuestionMarkingBase" and "QuestionMarkingBase" classes

            services.AddScoped<IExamMarkingBase, ExamMarkingBase>();    // Adds a scoped service for the "IExamMarkingBase" and "ExamMarkingBase" classes

            services.AddScoped<ISectionMarkingBase, SectionMarkingBase>();  // Adds a scoped service for the "ISectionMarkingBase" and "SectionMarkingBase" classes

            // Return the updated service collection
            return services;

        }

    }
}
