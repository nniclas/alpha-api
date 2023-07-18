using alpha_api.Models;

namespace alpha_api.Data
{
    public interface IEntryRepository
    {
        public List<Entry> GetEntries();
        public Entry GetEntry(int id);
        public void AddEntry(Entry entry);
        public void UpdateEntry(Entry entry);
        public Entry DeleteEntry(int id);
        public bool CheckEntry(int id);
    }
}
