using alpha_api.Models;
using Microsoft.EntityFrameworkCore;

namespace alpha_api.Data
{
    public class EventRepository : IEventRepository
    {
        readonly AlphaContext context = new();

        public EventRepository(AlphaContext context)
        {
            this.context = context;
        }

        public List<Event> GetAll()
        {
            try
            {
                return context.Events.ToList();
            }
            catch
            {
                throw;
            }
        }

        public Event Get(int id)
        {
            try
            {
                Event? ev = context.Events.Find(id);
                if (ev != null)
                {
                    return ev;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public void Add(Event Event)
        {
            try
            {
                context.Events.Add(Event);
                context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void Update(Event ev)
        {
            try
            {
                context.Entry(ev).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public Event Delete(int id)
        {
            try
            {

                var ev = context.Events.Find(id);
                if (ev != null)
                {
                    context.Events.Remove(ev);
                    context.SaveChanges();
                    return ev;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }

        public bool Exists(int id)
        {
            return context.Events.Any(e => e.Id == id);
        }
    }
}