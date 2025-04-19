using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.BaseRepository;

namespace Application.Interfaces.User
{
    public interface IUserRepository : IRepository<Domain.Entities.User, Guid>
    {
    }
}
