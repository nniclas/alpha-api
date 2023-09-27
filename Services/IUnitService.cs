using alpha_api.Models;

namespace alpha_api.Services
{
    public interface IUnitService
    {
        Task<List<Unit>> GetAllAsync();
        Task<Unit> GetAsync(int id);
        Task<bool> AddAsync(Unit unit);
        Task<bool> UpdateAsync(Unit unit);
        Task<bool> DeleteAsync(int id);
    }
}
