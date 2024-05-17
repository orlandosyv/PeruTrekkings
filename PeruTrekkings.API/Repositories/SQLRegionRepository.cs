using Microsoft.EntityFrameworkCore;
using PeruTrekkings.API.Data;
using PeruTrekkings.API.Models.Domain;
using PeruTrekkings.API.Models.DTO;

namespace PeruTrekkings.API.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly PeruTrekkingsDbContext dbContext;
        public SQLRegionRepository(PeruTrekkingsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Region> CreateAsync(Region region)
        {
            await dbContext.Regions.AddAsync(region);
            await dbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var regionDB = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (regionDB == null) { return null; }
            dbContext.Regions.Remove(regionDB);
            await dbContext.SaveChangesAsync();
            return regionDB;
        }

        public async Task<List<Region>> GetAllAsync()
        {
            return await dbContext.Regions.ToListAsync();
            
        }

        public async Task<Region?> GetByIdAsync(Guid id)
        {
            return await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var regionDB = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (regionDB == null) { return null; }

            //map
            regionDB.Code = region.Code;
            regionDB.Name = region.Name;
            regionDB.RegionImageUrl = region.RegionImageUrl;

            await dbContext.SaveChangesAsync();
            return regionDB;
        }
    }
}
