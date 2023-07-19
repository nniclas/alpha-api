using alpha_api.Models;

namespace alpha_api.Services
{
    public interface IEventService
    {
        List<Event> GetAll();
        Event Get(int id);
        bool Add(Event ev);
        bool Update(Event ev);
        Event Delete(int id);
    }
}
