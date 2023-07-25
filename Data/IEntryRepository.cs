using alpha_api.Models;

namespace alpha_api.Data
{
    public interface IEntryRepository
    {
        public List<Entry> GetAll();
        public List<Entry> GetAllByUnitId(int unitId);
        public Entry Get(int id);
        public void Add(Entry entry);
        public void Update(Entry entry);
        public Entry Delete(int id);
        public bool Exists(int id);
    }
}
