using alpha_api.Models;

namespace alpha_api.Services
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();
        Task<User> GetAsync(int id);
        Task<User> GetByEmailAsync(string email);
    }
}
