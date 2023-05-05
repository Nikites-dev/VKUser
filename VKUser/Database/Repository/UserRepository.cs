using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using VKUser.Models;

namespace VKUser.Database.Repository
{
    public class UserRepository: Repository<User>
    {
        public UserRepository(DatabaseContext context) : base(context)
        {
            
        }

        public async Task<User> GetByLoginAsync(String login)
        {
            return await _context.User.FirstOrDefaultAsync(x => x.Login == login);
        }
    }
}