using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Application.Common.PasswordHasher;
using Application.Features.Brand.Commands.Add;
using Application.Interfaces.PasswordHasher;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationConfig
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(AddBrandCommandHandler).Assembly));

            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddHttpContextAccessor();


            return services;
        }
    }
}
