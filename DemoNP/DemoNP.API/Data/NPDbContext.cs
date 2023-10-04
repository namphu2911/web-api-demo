using DemoNP.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DemoNP.API.Data
{
    public class NPDbContext : DbContext
    {
        public NPDbContext(DbContextOptions<NPDbContext> options) : base(options)
        {
            
        }

        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }
        public DbSet<WalkDifficulty> WalkDifficulties { get; set; }

    }
}
