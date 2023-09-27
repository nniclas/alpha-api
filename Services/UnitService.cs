using alpha_api.Data;
using alpha_api.Models;
using Microsoft.EntityFrameworkCore;

namespace alpha_api.Services
{
    
    // intermediary service, when this grows with more complex relations and fetches a service will help

    public class UnitService : IUnitService
    {
        private readonly IRepository<Unit> repository;

        public UnitService(IRepository<Unit> repository)
        {
            this.repository = repository;
        }

        public async Task<List<Unit>> GetAllAsync()
        {
            return (await this.repository.GetAllAsync()).ToList();
        }

        public async Task<Unit> GetAsync(int id)
        {
            return await repository.GetAsync(id);
        }

        public async Task<bool> AddAsync(Unit unit)
        {
            await repository.CreateAsync(unit);
            return true;
        }

        public async Task<bool> UpdateAsync(Unit unit) 
        {
            try
            {
                await repository.UpdateAsync(unit);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await repository.ExistsAsync(unit.Id))
                    return false;
                throw;
            }
            return true;
        }
            
        public async Task<bool> DeleteAsync(int id) 
        { 
            return await repository.DeleteAsync(id); 
        }


    }
}
