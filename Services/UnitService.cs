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

        public List<Unit> GetAll()
        {
            return this.repository.GetAll().ToList();
        }

        public Unit Get(int id)
        {
            return repository.Get(id);
        }

        public bool Add(Unit unit)
        {
            repository.Create(unit);
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
            
        public bool Delete(int id) 
        { 
            return repository.Delete(id); 
        }


    }
}
