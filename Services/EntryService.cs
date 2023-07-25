using alpha_api.Data;
using alpha_api.Models;
using Microsoft.EntityFrameworkCore;

namespace alpha_api.Services
{
    
    // intermediary service, when this grows with more complex relations and fetches a service will help

    public class EntryService : IEntryService
    {
        private readonly IEntryRepository entryRepository;

        public EntryService(IEntryRepository entryRepository)
        {
            this.entryRepository = entryRepository;
        }

        public List<Entry> GetAll()
        {
            return this.entryRepository.GetAll();
        }

        public List<Entry> GetAllByUnitId(int unitId)
        {
            return this.entryRepository.GetAllByUnitId(unitId);
        }
        
        public Entry Get(int id)
        {
            return entryRepository.Get(id);
        }

        public bool Add(Entry entry)
        {
            entryRepository.Add(entry);
            return true;
        }

        public bool Update(Entry entry) 
        {
            try
            {
                entryRepository.Update(entry);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!entryRepository.Exists(entry.Id))
                    return false;
                throw;
            }
            return true;
        }
            
        public Entry Delete(int id) 
        { 
            return entryRepository.Delete(id); 
        }


    }
}
