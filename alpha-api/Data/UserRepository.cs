using alpha_api.Models;
using Microsoft.EntityFrameworkCore;

namespace alpha_api.Data
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        readonly AlphaContext context = new();

        public async Task<User> GetByEmailAsync(string email)
        {
            try
            {
                var user = await context.Users.SingleOrDefaultAsync((u) => u.Email == email);
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