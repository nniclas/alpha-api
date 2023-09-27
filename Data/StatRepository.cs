using alpha_api.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace alpha_api.Data
{
    public class StatRepository : Repository<Stat>
    {
        //readonly AlphaContext context = new();

        //public StatRepository(AlphaContext context)
        //{
        //    this.context = context;
        //}

        //public Stat Get(int id)
        //{
        //    try
        //    {
        //        Stat? unit = context.Stats.Find(id);
        //        if (unit != null)
        //        {
        //            return unit;
        //        }
        //        else
        //        {
        //            throw new ArgumentNullException();
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        //public IEnumerable<Stat> GetAll()
        //{
        //    try
        //    {
        //        return context.Stats.ToList();
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        //public IEnumerable<Stat> Query(Expression<Func<Stat, bool>> predicate)
        //{
        //    try
        //    {
        //        return context.Stats
        //            .Where(predicate)
        //            .ToList();
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        //public bool Create(Stat stat)
        //{
        //    try
        //    {
        //        context.Stats.Add(stat);
        //        context.SaveChanges();
        //        return true;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        //public bool Update(Stat stat)
        //{
        //    try
        //    {
        //        context.Entry(stat).State = EntityState.Modified;
        //        context.SaveChanges();
        //        return true;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        //public bool Delete(int id)
        //{
        //    try
        //    {

        //        var stat = context.Stats.Find(id);
        //        if (stat != null)
        //        {
        //            context.Stats.Remove(stat);
        //            context.SaveChanges();
        //            return true;
        //        }
        //        else
        //        {
        //            throw new ArgumentNullException();
        //        }
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        //public bool Exists(int id)
        //{
        //    return context.Stats.Any(e => e.Id == id);
        //}
    }
}