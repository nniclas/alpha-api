using alpha_api.Data;
using alpha_api.Models;
using Microsoft.EntityFrameworkCore;

namespace alpha_api.Services
{
    
    // intermediary service, when this grows with more complex relations and fetches a service will help

    public class UserService : IUserService
    {
        private readonly IUserRepository repository;

        public UserService(IUserRepository repository)
        {
            this.repository = repository;
        }

        public async Task<List<User>> GetAllAsync()
        {
            return (await this.repository.GetAllAsync()).ToList();
        }

        public async Task<User> GetAsync(int id)
        {
            return await repository.GetAsync(id);
        }

        public async Task<User> GetByEmailAsync(string email)
        {
            return await repository.GetByEmailAsync(email);
        }
    }
}
