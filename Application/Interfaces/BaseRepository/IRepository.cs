using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Application.Interfaces.BaseRepository
{
    public interface IRepository<TEntity,TKey> where TEntity : class, IEntity<TKey>
    {
        Task<TEntity?> GetByIdAsync(TKey id);
        Task<TKey> AddAsync(TEntity entity, CancellationToken cancellationToken);
        void Update(TEntity entity);
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate);
        public Task<bool> SoftDelete(TEntity entity);
        public void Delete(TEntity entity);
        public IQueryable<TEntity> GetQueryable();
        public Task<List<TEntity>> GetList(CancellationToken cancellationToken = default);
    }
}
