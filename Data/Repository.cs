using alpha_api.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace alpha_api.Data
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        readonly AlphaContext context = new();

        public async Task<TEntity> Get(int id)
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

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            try
            {
                return context.Entries
                    .Include((x) => x.User)
                    .Include((x) => x.Unit)
                    .ToList();
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<Entry> Query(Expression<Func<Entry, bool>> predicate)
        {
            try
            {
                return context.Entries
                    .Where(predicate)
                    .Include((x) => x.User)
                    .Include((x) => x.Unit)
                    .ToList();
            }
            catch
            {
                throw;
            }
        }

        public async Task<bool> Create(Entry entry)
        {
            try
            {
                context.Entries.AddAsync(entry);
                await context.SaveChangesAsync();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public bool Update(Entry entry)
        {
            try
            {
                context.Entry(entry).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public bool Delete(int id)
        {
            try
            {

                var entry = context.Entries.Find(id);
                if (entry != null)
                {
                    context.Entries.Remove(entry);
                    context.SaveChanges();
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

        public bool Exists(int id)
        {
            return context.Entries.Any(e => e.Id == id);
        }

        //public async Task<User> GetAsync(int id)
        //{
        //    try
        //    {
        //        var user = await context.Users.FindAsync(id);
        //        if (user != null)
        //        {
        //            return user;
        //        }
        //        else
        //        {
        //            throw new ArgumentNullException();
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}
    }

    //Task<TItem> GetAsync(int id);
    //Task<IEnumerable<TItem>> GetAllAsync();
    //Task<IEnumerable<TItem>> QueryAsync(Expression<Func<TItem, bool>> predicate);
    //Task<bool> CreateAsync(TItem item);
    //Task<bool> UpdateAsync(TItem item);
    //Task<bool> DeleteAsync(int id);
    //Task<bool> ExistsAsync(int id);
}
