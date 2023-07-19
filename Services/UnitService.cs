using alpha_api.Data;
using alpha_api.Models;
using Microsoft.EntityFrameworkCore;

namespace alpha_api.Services
{
    
    // intermediary service, when this grows with more complex relations and fetches a service will help

    public class UnitService : IUnitService
    {
        private readonly IUnitRepository repository;

        public UnitService(IUnitRepository repository)
        {
            this.repository = repository;
        }

        public List<Unit> GetAll()
        {
            return this.repository.GetAll();
        }

        public Unit Get(int id)
        {
            return repository.Get(id);
        }

        public bool Add(Unit unit)
        {
            repository.Add(unit);
            return true;
        }

        public bool Update(Unit unit) 
        {
            try
            {
                repository.Update(unit);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!repository.Exists(unit.Id))
                    return false;
                throw;
            }
            return true;
        }
            
        public Unit Delete(int id) 
        { 
            return repository.Delete(id); 
        }


    }
}
