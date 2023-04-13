using ApplicationDbContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;

namespace Domain.DependencyResolver {
    public static class ServiceCollectionExtension {
        public static void AddDatabaseContext(this IServiceCollection services) {
            // Add a new instance of the MarkingDbContext to the service collection with an in-memory database provider
            services.AddDbContext<MarkingDbContext>(options => options.UseInMemoryDatabase("memory-db"));

            // SEED DATABASE
            
        }
    }
}
