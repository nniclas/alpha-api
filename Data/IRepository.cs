using System.Linq.Expressions;

namespace alpha_api.Data
{
    public interface IRepository<TItem> where TItem : class
    {
        TItem Get(int id);
        IEnumerable<TItem> GetAll();
        IEnumerable<TItem> Query(Expression<Func<TItem, bool>> predicate);
        bool Create(TItem item);
        bool Update(TItem item);
        bool Delete(int id);
        bool Exists(int id);
    }
}
