using alpha_api.Models;

namespace alpha_api.Services
{
    public interface IEntryService
    {
        List<Entry> GetAll();
        List<Entry> GetAllByUnit(int unitId);
        List<Entry> GetAllByUnitAndWeek(int unitId, string week);
        Entry Get(int id);
        bool Add(Entry entry);
        bool Update(Entry entry);
        bool Delete(int id);
    }
}
