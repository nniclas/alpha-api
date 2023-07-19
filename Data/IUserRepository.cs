using alpha_api.Models;

namespace alpha_api.Data
{
    public interface IUserRepository
    {
        public List<User> GetAll();
        public User Get(int id);
    }
}
