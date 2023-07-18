using alpha_api.Models;
using Microsoft.EntityFrameworkCore;

namespace alpha_api.Data
{
    public class EntryRepository : IEntry
    {
        readonly AlphaContext context = new();

        public EntryRepository(AlphaContext context)
        {
            this.context = context;
        }

        public List<Entry> GetEntries()
        {
            try
            {
                return context.Entries.ToList();
            }
            catch
            {
                throw;
            }
        }

        public Entry GetEntry(int id)
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

        public void AddEntry(Entry entry)
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

        public void UpdateEntry(Entry entry)
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

        public void DeleteEntry(int id)
        {
            try
            {
                Entry? entry = context.Entries.Find(id);                
                context.Entries.Remove(entry);
                context.SaveChanges();
                
            }
            catch
            {
                throw;
            }
        }
    }
}