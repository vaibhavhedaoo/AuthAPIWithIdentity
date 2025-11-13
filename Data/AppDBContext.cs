using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using AuthService.Models;

namespace AuthService.Data
{
    public class AppDBContext : IdentityDbContext<User>
    {
        // Constructor
        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        // Example DbSet
        public new DbSet<User> Users { get; set; }
    }
}
