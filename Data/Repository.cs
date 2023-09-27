using alpha_api.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace alpha_api.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        readonly AlphaContext context = new();

        public async Task<TEntity> GetAsync(int id)
        {
            try
            {
                TEntity? entity = await context.Set<TEntity>().FindAsync(id);
                if (entity != null)
                {
                    return entity;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            try
            {
                return await context.Set<TEntity>()
                    //.Include((x) => x.User)
                    //.Include((x) => x.Unit)
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<IEnumerable<TEntity>> QueryAsync(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return await context.Set<TEntity>()
                    .Where(predicate)
                    //.Include((x) => x.User)
                    //.Include((x) => x.Unit)
                    .ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> CreateAsync(TEntity entity)
        {
            try
            {
                context.Set<TEntity>().AddAsync(entity);
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> UpdateAsync(TEntity entity)
        {
            try
            {
                context.Entry(entity).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            try
            {

                var entity = await context.Set<TEntity>().FindAsync(id);
                if (entity != null)
                {
                    context.Set<TEntity>().Remove(entity);
                    await context.SaveChangesAsync();
                    return true;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await context.Set<TEntity>().AnyAsync(e => e.Id == id);
        }
    }

}
