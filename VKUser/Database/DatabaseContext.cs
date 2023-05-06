using Microsoft.EntityFrameworkCore;
using VKUser.Models;

namespace VKUser.Database
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            
        }

        public DbSet<User> User { get; set; }
        public DbSet<UserGroup> UserGroup { get; set; }
    }
}