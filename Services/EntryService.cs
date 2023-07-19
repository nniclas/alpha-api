using alpha_api.Data;
using alpha_api.Models;
using Microsoft.EntityFrameworkCore;

namespace alpha_api.Services
{
    
    // intermediary service, when this grows with more complex relations and fetches a service will help

    public class EntryService : IEntryService
    {
        private readonly IEntryRepository repository;

        public EntryService(IEntryRepository repository)
        {
            this.repository = repository;
        }

        public List<Entry> GetAll()
        {
            return this.repository.GetAll();
        }

        public Entry Get(int id)
        {
            return repository.Get(id);
        }

        public bool Add(Entry entry)
        {
            repository.Add(entry);
            return true;
        }

        public bool Update(Entry entry) 
        {
            try
            {
                repository.Update(entry);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!repository.Exists(entry.Id))
                    return false;
                throw;
            }
            return true;
        }
            
        public Entry Delete(int id) 
        { 
            return repository.Delete(id); 
        }


    }
}
