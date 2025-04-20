using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Application.Common.PasswordHasher;
using Application.Interfaces.PasswordHasher;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationConfig
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


            return services;
        }
    }
}
