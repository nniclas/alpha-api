using alpha_api.Models;

namespace alpha_api.Services
{
    public interface IUnitService
    {
        List<Unit> GetAll();
        Unit Get(int id);
        bool Add(Unit unit);
        bool Update(Unit unit);
        bool Delete(int id);
    }
}
