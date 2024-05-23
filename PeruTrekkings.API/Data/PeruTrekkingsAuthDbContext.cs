using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PeruTrekkings.API.Data
{
    public class PeruTrekkingsAuthDbContext : IdentityDbContext
    {
        public PeruTrekkingsAuthDbContext(DbContextOptions<PeruTrekkingsAuthDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            var readerId = "0f34e514-743a-4da0-887c-ba832848aa79";
            var writerId = "cb69abb2-7f94-499b-aaf4-69fe12654ee7";

            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Id = readerId,
                    ConcurrencyStamp = readerId,
                    Name = "Reader",
                    NormalizedName = "Reader".ToUpper(),
            
                },
                new IdentityRole
                {
                    Id = writerId,
                    ConcurrencyStamp = writerId,
                    Name = "Writer",
                    NormalizedName = "Writer".ToUpper(),
                }
            };

            builder.Entity<IdentityRole>().HasData(roles);

        }

    }
}
