using FootballLeague.DAL.Interfaces;
using FootballLeague.Domain;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FootballLeague.DAL.Repositories
{
    public abstract class GenericRepository<TEntity> : IGenericRepository<TEntity>
        where TEntity : class
    {
        private readonly ApplicationDbContext context;

        public GenericRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public DbSet<TEntity> DbSet => context.Set<TEntity>();

        public async Task<IEnumerable<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> predicate = null)
        {
            if (predicate != null)
            {
                return await DbSet.Where(predicate).ToListAsync();
            }

            return await DbSet.ToListAsync();
        }

        public async Task<TEntity> GetByIdAsync<TKey>(TKey id)
            => await DbSet.FindAsync(id);

        public Task CreateAsync(TEntity entity)
        {
            DbSet.Add(entity);

            return SaveChangesAsync();
        }

        public Task SoftDeleteAsync<TDeletable>(TDeletable entity)
            where TDeletable : TEntity, IDeletable
        {
            entity.IsDeleted = true;

            return SaveChangesAsync();
        }

        public Task SaveChangesAsync()
            => context.SaveChangesAsync();
    }
}
