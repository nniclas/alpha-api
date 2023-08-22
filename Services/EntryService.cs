using alpha_api.Data;
using alpha_api.Models;
using alpha_api.Core;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace alpha_api.Services
{
    
    // intermediary service, when this grows with more complex relations and fetches a service will help

    public class EntryService : IEntryService
    {
        private readonly IRepository<Entry> entryRepository;

        public EntryService(IRepository<Entry> entryRepository)
        {
            this.entryRepository = entryRepository;
        }

        public List<Entry> GetAll()
        {
            return this.entryRepository.GetAll().ToList();
        }

        public List<Entry> GetAllByUnit(int unitId)
        {
            return this.entryRepository.Query((e) => e.UnitId == unitId).ToList();
        }

        public List<Entry> GetAllByUnitAndWeek(int unitId, string week)
        {
            return this.entryRepository.Query((e) => 
                e.UnitId == unitId &&   
                e.Date >=  week.ToDateTime(DayOfWeek.Sunday) && 
                e.Date <= week.ToDateTime(DayOfWeek.Saturday))
                .ToList();
        }

        public Entry Get(int id)
        {
            return entryRepository.Get(id);
        }

        public bool Add(Entry entry)
        {
            entryRepository.Create(entry);
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
            
        public bool Delete(int id) 
        { 
            return entryRepository.Delete(id); 
        }


    }
}
