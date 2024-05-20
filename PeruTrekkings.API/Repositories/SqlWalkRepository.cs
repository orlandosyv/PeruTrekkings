using PeruTrekkings.API.Data;
using PeruTrekkings.API.Models.Domain;

namespace PeruTrekkings.API.Repositories
{
    public class SqlWalkRepository : IWalkRepository
    {
        private readonly PeruTrekkingsDbContext dbContext;

        public SqlWalkRepository(PeruTrekkingsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Walk> CreateAsync(Walk walk)
        {
            await dbContext.Walks.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;
        }
    }
}
