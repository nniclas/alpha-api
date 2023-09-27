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

        public async Task<User> Get(int id)
        {
            try
            {
                var user = await context.Users.FindAsync(id);
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

        public async Task<List<User>> GetAll()
        {
            try
            {
                return await context.Set<User>().ToListAsync();
            }
            catch
            {
                throw;
            }
        }

        public async Task<User> GetByEmail(string email)
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