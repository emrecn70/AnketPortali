using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AnketPortali.Models
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDbContext(DbContextOptions options) : base(options)
        
        {
        }
        public DbSet<Anket> Ankets { get; set; }
        public DbSet<Soru> Sorus { get; set; }
    }
}
