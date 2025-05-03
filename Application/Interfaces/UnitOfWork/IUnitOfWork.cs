using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.Brand;
using Application.Interfaces.Category;
using Application.Interfaces.Offer;
using Application.Interfaces.Product;
using Application.Interfaces.ProductColor;
using Application.Interfaces.ProductOffer;
using Application.Interfaces.ProductRating;
using Application.Interfaces.ShoppingCart;
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
        IOfferRepository OfferRepository { get; }

        ICategoryRepository CategoryRepository { get; }

        IProductOfferRepository ProductOfferRepository { get; }

        public IShoppingCartRepository ShoppingCartRepository { get; }

        public Task<int> SaveAsync();

    }
}
