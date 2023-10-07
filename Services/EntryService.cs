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

        public async Task<List<Entry>> GetAllAsync()
        {
            return (await this.entryRepository.GetAllAsync()).ToList();
        }

        public async Task<List<Entry>> GetAllByUnitAsync(int unitId)
        {
            return (await this.entryRepository.QueryAsync((e) => e.UnitId == unitId)).ToList();
        }

        public async Task<List<Entry>> GetAllByUnitAndWeekAsync(int unitId, string week)
        {
            return (await this.entryRepository.QueryAsync((e) => 
                e.UnitId == unitId &&   
                e.Date >=  week.ToDateTime(DayOfWeek.Monday) && 
                e.Date <= week.ToDateTime(DayOfWeek.Sunday)))
                .ToList();
        }

        public async Task<Entry> GetAsync(int id)
        {
            return await entryRepository.GetAsync(id);
        }

        public async Task<Entry> AddAsync(Entry entry)
        {
            var e = await entryRepository.CreateAsync(entry);
            return e;
        }

        public async Task<Entry> UpdateAsync(Entry entry) 
        {
            try
            {
                var e = await entryRepository.UpdateAsync(entry);
                return e;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }
        }
            
        public async Task<bool> DeleteAsync(int id) 
        { 
            return await entryRepository.DeleteAsync(id); 
        }


    }
}
