using FootballLeague.Domain;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FootballLeague.DAL.Interfaces
{
    public interface IGenericRepository<TEntity>
        where TEntity : class
    {
        Task<IEnumerable<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> filter = null);

        Task<TEntity> GetByIdAsync<TKey>(TKey id);

        Task CreateAsync(TEntity entity);

        Task SoftDeleteAsync<TDeletable>(TDeletable entity)
            where TDeletable : TEntity, IDeletable;

        Task SaveChangesAsync();
    }
}
