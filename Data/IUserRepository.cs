using alpha_api.Models;

namespace alpha_api.Data
{
    public interface IUserRepository
    {
        public Task<IEnumerable<User>> GetAll();
        public Task<User> Get(int id);
        public Task<User> GetByEmail(string email);
    }
}
