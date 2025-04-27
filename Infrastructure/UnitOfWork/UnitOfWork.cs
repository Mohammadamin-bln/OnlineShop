using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Brand;
using Application.Interfaces.Product;
using Application.Interfaces.ProductColor;
using Application.Interfaces.ProductRating;
using Application.Interfaces.UnitOfWork;
using Application.Interfaces.User;
using Infrastructure.Contexts;
using Infrastructure.Repositories.Product;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.UnitOfWork
{
    public class UnitOfWork :  IUnitOfWork
    {

        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context,
            IUserRepository userRepository,
            IProductRepository productRepository,
            IProductColorRepository productColorRepository,
            IBrandRepository brandRepository,
            IProductRatingRepository productRatingRepository)
        {
            _context = context;
            UserRepository = userRepository;
            ProductRepository = productRepository;
            ProductColorRepository = productColorRepository;
            BrandRepository = brandRepository;
            ProductRatingRepository = productRatingRepository;


        }
        public IProductRatingRepository ProductRatingRepository { get; }
        public IUserRepository UserRepository { get; }
        public IProductRepository ProductRepository { get; }

        public IBrandRepository BrandRepository { get; }
        public IProductColorRepository ProductColorRepository { get; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }
    }
}
