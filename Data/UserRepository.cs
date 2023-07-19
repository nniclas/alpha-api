using alpha_api.Models;
using Microsoft.EntityFrameworkCore;

namespace alpha_api.Data
{
    public class UserRepository : IUserRepository
    {
        readonly AlphaContext context = new();

        public UserRepository(AlphaContext context)
        {
            this.context = context;
        }

        public List<User> GetAll()
        {
            try
            {
                return context.Users.ToList();
            }
            catch
            {
                throw;
            }
        }

        public User Get(int id)
        {
            try
            {
                User? user = context.Users.Find(id);
                if (user != null)
                {
                    return user;
                }
                else
                {
                    throw new ArgumentNullException();
                }
            }
            catch
            {
                throw;
            }
        }
    }
}