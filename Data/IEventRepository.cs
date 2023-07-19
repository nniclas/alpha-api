using alpha_api.Models;

namespace alpha_api.Data
{
    public interface IEventRepository
    {
        public List<Event> GetAll();
        public Event Get(int id);
        public void Add(Event ev);
        public void Update(Event ev);
        public Event Delete(int id);
        public bool Exists(int id);
    }
}
