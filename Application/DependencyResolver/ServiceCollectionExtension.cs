﻿using Microsoft.Extensions.DependencyInjection;
using RepoInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DependencyResolver {
    public static class ServiceCollectionExtensions {

        public static IServiceCollection AddApplication(this IServiceCollection services) {


            services.AddDomain();
            services.AddTransient<Marking>();
            return services;

        }

    }
}
