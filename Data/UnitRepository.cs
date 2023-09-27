using alpha_api.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace alpha_api.Data
{
    public class UnitRepository : Repository<Unit>
    {
        //readonly AlphaContext context = new();

        //public UnitRepository(AlphaContext context)
        //{
        //    this.context = context;
        //}

        //public Unit Get(int id)
        //{
        //    try
        //    {
        //        Unit? unit = context.Units.Find(id);
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

        //public IEnumerable<Unit> GetAll()
        //{
        //    try
        //    {
        //        return context.Units.ToList();
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        //public IEnumerable<Unit> Query(Expression<Func<Unit, bool>> predicate)
        //{
        //    try
        //    {
        //        return context.Units
        //            .Where(predicate)
        //            .ToList();
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        //public bool Create(Unit unit)
        //{
        //    try
        //    {
        //        context.Units.Add(unit);
        //        context.SaveChanges();
        //        return true;
        //    }
        //    catch
        //    {
        //        throw;
        //    }
        //}

        //public bool Update(Unit unit)
        //{
        //    try
        //    {
        //        context.Entry(unit).State = EntityState.Modified;
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

        //        var unit = context.Units.Find(id);
        //        if (unit != null)
        //        {
        //            context.Units.Remove(unit);
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
        //    return context.Units.Any(e => e.Id == id);
        //}
    }
}