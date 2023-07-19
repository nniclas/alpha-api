using alpha_api.Data;
using alpha_api.Models;
using Microsoft.EntityFrameworkCore;

namespace alpha_api.Services
{
    
    // intermediary service, when this grows with more complex relations and fetches a service will help

    public class EventService : IEventService
    {
        private readonly IEventRepository repository;

        public EventService(IEventRepository repository)
        {
            this.repository = repository;
        }

        public List<Event> GetAll()
        {
            return this.repository.GetAll();
        }

        public Event Get(int id)
        {
            return repository.Get(id);
        }

        public bool Add(Event ev)
        {
            repository.Add(ev);
            return true;
        }

        public bool Update(Event ev) 
        {
            try
            {
                repository.Update(ev);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!repository.Exists(ev.Id))
                    return false;
                throw;
            }
            return true;
        }
            
        public Event Delete(int id) 
        { 
            return repository.Delete(id); 
        }


    }
}
