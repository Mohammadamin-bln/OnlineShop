using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.User;
using Domain.Entities;
using Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace Infrastructure.Repositories.User
{
    public class UserRepository : BaseRepository<Domain.Entities.User, Guid>, IUserRepository
    {

        private readonly ApplicationDbContext _Context;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _Context = context;
        }
        public Task<Domain.Entities.User?> GetUserByPhoneNumber(string phoneNumber)
        {
            return _context.Users.SingleOrDefaultAsync(u => u.PhoneNumber == phoneNumber);
        }

    }
}
