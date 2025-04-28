using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Contexts
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { 
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Otp> Otps { get; set; }

        public DbSet<Product> Products  { get; set; }

        public DbSet<Brand> Brands { get; set; }

        public DbSet<ProductColor> ProductColors { get; set; }

        public DbSet<ProductRating> ProductRatings { get; set; }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Offer> Offers { get; set; }
        public DbSet<ProductOffer> ProductOffers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var baseType = entityType.ClrType.BaseType;

                if (baseType != null &&
                    baseType.IsGenericType &&
                    baseType.GetGenericTypeDefinition() == typeof(BaseEntity<>))
                {
                    var method = typeof(ApplicationDbContext)
                        .GetMethod(nameof(SetGlobalQueryFilter), System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
                        .MakeGenericMethod(entityType.ClrType);

                    method.Invoke(null, new object[] { modelBuilder });
                }
            }
        }

        private static void SetGlobalQueryFilter<TEntity>(ModelBuilder builder)
            where TEntity : class
        {
            builder.Entity<TEntity>().HasQueryFilter(e => EF.Property<bool>(e, "IsDeleted") == false);
        }
    }

}
