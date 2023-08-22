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

        public List<User> GetAll()
        {
            return this.repository.GetAll().ToList();
        }

        public User Get(int id)
        {
            return repository.Get(id);
        }

        public User GetByEmail(string email)
        {
            return repository.GetByEmail(email);
        }
    }
}
