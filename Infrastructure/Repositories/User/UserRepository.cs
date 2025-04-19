using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.User;
using Domain.Entities;
using Infrastructure.Contexts;

namespace Infrastructure.Repositories.User
{
    public class UserRepository : BaseRepository<Domain.Entities.User, Guid>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
