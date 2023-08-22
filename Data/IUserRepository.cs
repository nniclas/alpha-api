using alpha_api.Models;

namespace alpha_api.Data
{
    public interface IUserRepository
    {
        public IEnumerable<User> GetAll();
        public User Get(int id);
        public User GetByEmail(string email);
    }
}
