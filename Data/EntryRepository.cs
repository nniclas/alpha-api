using alpha_api.Models;
using Microsoft.EntityFrameworkCore;

namespace alpha_api.Data
{
    public class EntryRepository : IEntryRepository
    {
        readonly AlphaContext context = new();

        public EntryRepository(AlphaContext context)
        {
            this.context = context;
        }

        public List<Entry> GetAll()
        {
            try
            {
                return context.Entries.Include((x) => x.Unit).ToList();
            }
            catch
            {
                throw;
            }
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

        public void Add(Entry entry)
        {
            try
            {
                context.Entries.Add(entry);
                context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void Update(Entry entry)
        {
            try
            {
                context.Entry(entry).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public Entry Delete(int id)
        {
            try
            {

                var entry = context.Entries.Find(id);
                if (entry != null)
                {
                    context.Entries.Remove(entry);
                    context.SaveChanges();
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

        public bool Exists(int id)
        {
            return context.Entries.Any(e => e.Id == id);
        }
    }
}