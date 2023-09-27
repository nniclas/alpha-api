using System.Linq.Expressions;

namespace alpha_api.Data
{
    public interface IRepository<TItem> where TItem : class
    {
        Task<TItem> GetAsync(int id);
        Task<IEnumerable<TItem>> GetAllAsync();
        Task<IEnumerable<TItem>> QueryAsync(Expression<Func<TItem, bool>> predicate);
        Task<bool> CreateAsync(TItem item);
        Task<bool> UpdateAsync(TItem item);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
