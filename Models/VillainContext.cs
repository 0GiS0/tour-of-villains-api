using Microsoft.EntityFrameworkCore;

namespace tour_of_villains_api.Models
{
    public class VillainContext : DbContext
    {
        public VillainContext(DbContextOptions<VillainContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Villain> Villains { get; set; }
        public DbSet<Hero> Heroes { get; set; }
    }
}
