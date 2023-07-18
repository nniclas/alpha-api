using alpha_api.Models;

namespace alpha_api.Data
{
    public interface IEntry
    {
        public List<Entry> GetEntries();
        public Entry GetEntry(int id);
        public void AddEntry(Entry entry);
        public void UpdateEntry(Entry entry);
        public void DeleteEntry(int id);
        
    }
}
