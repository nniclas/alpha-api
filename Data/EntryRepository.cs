using alpha_api.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace alpha_api.Data
{
    public class EntryRepository : IEntryRepository
    {
        readonly AlphaContext context = new();

        public EntryRepository(AlphaContext context)
        {
            this.context = context;
        }

        public Entry Get(int id)
        {
            try
            {
                Entry? entry = context.Entries.Find(id);
                if (entry != null)
                {
                    return entry;
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

        public IEnumerable<Entry> GetAll()
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

        public bool Create(Entry entry)
        {
            try
            {
                context.Entries.Add(entry);
                context.SaveChanges();
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
    }
}