using alpha_api.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace alpha_api.Data
{
    public class UnitStatsRepository : IUnitStatsRepository
    {
        readonly AlphaContext context = new();

        public UnitStatsRepository(AlphaContext context)
        {
            this.context = context;
        }

        public UnitStats Get(int id)
        {
            try
            {
                UnitStats? unit = context.UnitStats.Find(id);
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

        public IEnumerable<UnitStats> GetAll()
        {
            try
            {
                return context.UnitStats.ToList();
            }
            catch
            {
                throw;
            }
        }

        public IEnumerable<UnitStats> Query(Expression<Func<UnitStats, bool>> predicate)
        {
            try
            {
                return context.UnitStats
                    .Where(predicate)
                    .ToList();
            }
            catch
            {
                throw;
            }
        }

        public bool Create(UnitStats unitStats)
        {
            try
            {
                context.UnitStats.Add(unitStats);
                context.SaveChanges();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public bool Update(UnitStats unitStats)
        {
            try
            {
                context.Entry(unitStats).State = EntityState.Modified;
                context.SaveChanges();
                return true;
            }
            catch
            {
                throw;
            }
        }

        public bool Delete(int id)
        {
            try
            {

                var unit = context.Units.Find(id);
                if (unit != null)
                {
                    context.Units.Remove(unit);
                    context.SaveChanges();
                    return true;
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