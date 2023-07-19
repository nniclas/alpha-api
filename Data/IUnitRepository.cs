using alpha_api.Models;

namespace alpha_api.Data
{
    public interface IUnitRepository
    {
        public List<Unit> GetAll();
        public Unit Get(int id);
        public void Add(Unit unit);
        public void Update(Unit unit);
        public Unit Delete(int id);
        public bool Exists(int id);
    }
}
