using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Application.Interfaces.BaseRepository
{
    public interface IRepository<TEntity,TKey> where TEntity : class, IEntity<TKey>
    {
        Task<TEntity?> GetByIdAsync(TKey id);
        Task<TKey> AddAsync(TEntity entity);
        void Update(TEntity entity);
    }
}
