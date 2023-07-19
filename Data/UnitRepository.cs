using alpha_api.Models;
using Microsoft.EntityFrameworkCore;

namespace alpha_api.Data
{
    public class UnitRepository : IUnitRepository
    {
        readonly AlphaContext context = new();

        public UnitRepository(AlphaContext context)
        {
            this.context = context;
        }

        public List<Unit> GetAll()
        {
            try
            {
                return context.Units.ToList();
            }
            catch
            {
                throw;
            }
        }

        public Unit Get(int id)
        {
            try
            {
                Unit? unit = context.Units.Find(id);
                if (unit != null)
                {
                    return unit;
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

        public void Add(Unit unit)
        {
            try
            {
                context.Units.Add(unit);
                context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public void Update(Unit unit)
        {
            try
            {
                context.Entry(unit).State = EntityState.Modified;
                context.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        public Unit Delete(int id)
        {
            try
            {

                var unit = context.Units.Find(id);
                if (unit != null)
                {
                    context.Units.Remove(unit);
                    context.SaveChanges();
                    return unit;
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
            return context.Units.Any(e => e.Id == id);
        }
    }
}