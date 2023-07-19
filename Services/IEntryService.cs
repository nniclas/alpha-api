using alpha_api.Models;

namespace alpha_api.Services
{
    public interface IEntryService
    {
        List<Entry> GetAll();
        Entry Get(int id);
        bool Add(Entry entry);
        bool Update(Entry entry);
        Entry Delete(int id);
    }
}
