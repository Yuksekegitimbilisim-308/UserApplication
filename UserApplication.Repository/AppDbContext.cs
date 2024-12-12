using Microsoft.EntityFrameworkCore;
using UserApplication.Entity;

namespace UserApplication.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base 
            (options)
        {  
            
        }

        public DbSet<User> Users{ get; set; }
    }
}
