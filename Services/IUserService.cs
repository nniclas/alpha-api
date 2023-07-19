using alpha_api.Models;

namespace alpha_api.Services
{
    public interface IUserService
    {
        List<User> GetAll();
        User Get(int id);
    }
}
