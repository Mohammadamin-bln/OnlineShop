using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Brand;
using Application.Interfaces.Product;
using Application.Interfaces.ProductColor;
using Application.Interfaces.ProductRating;
using Application.Interfaces.User;

namespace Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository UserRepository { get; }
        IProductRepository ProductRepository { get; }

        IProductColorRepository ProductColorRepository { get; }
        IBrandRepository BrandRepository { get; }
        IProductRatingRepository ProductRatingRepository { get; }

        public Task<int> SaveAsync();

    }
}
