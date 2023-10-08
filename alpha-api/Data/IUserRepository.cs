using alpha_api.Models;

namespace alpha_api.Data
{
    public interface IUserRepository : IRepository<User>
    {
        public Task<User> GetByEmailAsync(string email);
    }
}
