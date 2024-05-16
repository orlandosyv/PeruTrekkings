using Microsoft.EntityFrameworkCore;
using PeruTrekkings.API.Models.Domain;

namespace PeruTrekkings.API.Data
{
    public class PeruTrekkingsDbContext : DbContext
    {
        public PeruTrekkingsDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        {

        }

        public DbSet<Difficulty>   Difficulties { get; set; }
        public DbSet<Region> Regions { get; set; }
        public DbSet<Walk> Walks { get; set; }


    }
}
