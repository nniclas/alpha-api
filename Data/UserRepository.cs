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

        public User Get(int id)
        {
            try
            {
                var user = context.Users.Find(id);
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

        public IEnumerable<User> GetAll()
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

        public User GetByEmail(string email)
        {
            try
            {
                var user = context.Users.SingleOrDefault((u) => u.Email == email);
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