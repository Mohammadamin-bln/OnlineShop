using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Interfaces.BaseRepository;

namespace Application.Interfaces.Category
{
    public interface ICategoryRepository : IRepository<Domain.Entities.Category,long>
    {
    }
}
