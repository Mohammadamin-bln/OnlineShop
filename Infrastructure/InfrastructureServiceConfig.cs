using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.BaseRepository;
using Application.Interfaces.Brand;
using Application.Interfaces.Category;
using Application.Interfaces.FileService;
using Application.Interfaces.Offer;
using Application.Interfaces.OfferService;
using Application.Interfaces.OtpService;
using Application.Interfaces.Product;
using Application.Interfaces.ProductColor;
using Application.Interfaces.ProductOffer;
using Application.Interfaces.ProductRating;
using Application.Interfaces.TokenProvider;
using Application.Interfaces.UnitOfWork;
using Application.Interfaces.User;
using Domain.Entities;
using Infrastructure.Authorization;
using Infrastructure.Contexts;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Brand;
using Infrastructure.Repositories.Category;
using Infrastructure.Repositories.Offer;
using Infrastructure.Repositories.Product;
using Infrastructure.Repositories.ProductColor;
using Infrastructure.Repositories.ProductOffer;
using Infrastructure.Repositories.ProductRating;
using Infrastructure.Repositories.User;
using Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace Infrastructure
{
    public static class InfrastructureServiceConfig
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
            });


            #region authorization config
            services.AddAuthorization();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(o =>
            {
                o.RequireHttpsMetadata = false;
                o.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Secret"]!)),
                    ValidIssuer = configuration["Jwt:Issuer"],
                    ValidAudience = configuration["Jwt:Audience"],
                    ClockSkew = TimeSpan.Zero
                };
            });
            #endregion


            #region Dependency Injection
            services.AddScoped(typeof(IRepository<,>), typeof(BaseRepository<,>));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddHttpClient<IOtpService, OtpService>();
            services.AddScoped<ITokenProvider, TokenProvider>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IProductRepository,ProductRepository>();
            services.AddScoped<IProductColorRepository,ProductColorRepository>();
            services.AddScoped<IBrandRepository, BrandRepository>();
            services.AddScoped<IProductRatingRepository, ProductRatingRepository>();
            services.AddScoped<IOfferRepository,OfferRepository>();
            services.AddScoped<IProductOfferRepository,ProductOfferRepository>();
            services.AddScoped<IOfferService,OfferService>();
            services.AddScoped<IUnitOfWork, Infrastructure.UnitOfWork.UnitOfWork>();



            services.AddScoped<ITokenProvider, TokenProvider>();

            #endregion

            return services;
        }
    }
}
