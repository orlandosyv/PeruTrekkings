using Microsoft.EntityFrameworkCore;
using PeruTrekkings.API.Data;
using PeruTrekkings.API.Models.Domain;

namespace PeruTrekkings.API.Repositories
{
    public class SQLRegionReposity : IRegionReposity
    {
        private readonly PeruTrekkingsDbContext dbContext;
        public SQLRegionReposity(PeruTrekkingsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<List<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
            
        }
    }
}
