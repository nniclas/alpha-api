using alpha_api.Data;
using alpha_api.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

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

        public async Task<Unit> AddAsync(Unit unit)
        {
            ///////////////////////////////////////////////////
            ///////////// DEMO (user access WIP) //////////////
            /// MAX 6 UNITS ///////////////////////////////////
            var units = await repository.GetAllAsync();
            if (units.ToList().Count >= 6)
                return null;
            //////////////// DEMO (user access WIP) ///////////
            ///////////////////////////////////////////////////
            ///////////////////////////////////////////////////

            var u = await repository.CreateAsync(unit);
            return u;
        }

        public async Task<Unit> UpdateAsync(Unit unit) 
        {
            ///////////////////////////////////////////////////
            ///////////// DEMO (user access WIP) //////////////
            /// PERSIST THE FIRST 4 UNITS /////////////////////
            if (unit.Id <= 4) 
                return null;
            //////////////// DEMO (user access WIP) ///////////
            ///////////////////////////////////////////////////
            //////////////////////////////////////////////////////

            try
            {
                var u = await repository.UpdateAsync(unit);
                return u;
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            }

        }
            
        public async Task<bool> DeleteAsync(int id) 
        {
            ///////////////////////////////////////////////////
            ///////////// DEMO (user access WIP) //////////////
            /// PERSIST THE FIRST 4 UNITS /////////////////////
            if (id <= 4) return false;
            //////////////// DEMO (user access WIP) ///////////
            ///////////////////////////////////////////////////
            //////////////////////////////////////////////////////

            return await repository.DeleteAsync(id); 
        }


    }
}
