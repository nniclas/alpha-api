using alpha_api.Models;

namespace alpha_api.Services
{
    public interface IEntryService
    {
        Task<List<Entry>> GetAllAsync();
        Task<List<Entry>> GetAllByUnitAsync(int unitId);
        Task<List<Entry>> GetAllByUnitAndWeekAsync(int unitId, string week);
        Task<Entry> GetAsync(int id);
        Task<Entry> AddAsync(Entry entry);
        Task<Entry> UpdateAsync(Entry entry);
        Task<bool> DeleteAsync(int id);
    }
}
