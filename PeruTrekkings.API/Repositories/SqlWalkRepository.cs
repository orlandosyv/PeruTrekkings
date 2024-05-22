using Microsoft.EntityFrameworkCore;
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

        public async Task<Walk?> DeleteAsync(Guid id)
        {
            var walkDB = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (walkDB == null) { return null; }
            dbContext.Walks.Remove(walkDB);
            await dbContext.SaveChangesAsync();
            return walkDB;
        }

        public async Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery = null,
             string? sortBy = null, bool isAscending = true,
             int pageNumber = 1, int pageSize = 4)
        {
            var walks = dbContext.Walks.Include(x => x.Difficulty).Include("Region").AsQueryable();
            //filter
            if(string.IsNullOrWhiteSpace(filterOn) == false && string.IsNullOrWhiteSpace(filterQuery) == false) 
            {
                if (filterOn.Equals("Name", StringComparison.OrdinalIgnoreCase)) 
                {
                    walks = walks.Where(x => x.Name.Contains(filterQuery)); 
                }
                
            }

            //sorting
            if (string.IsNullOrWhiteSpace(sortBy) == false)
            {
                if (sortBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                {
                    walks = isAscending ? walks.OrderBy(x => x.Name) : walks.OrderByDescending(x => x.Name);
                } 
                else if (sortBy.Equals("Length", StringComparison.OrdinalIgnoreCase)) 
                {
                    walks = isAscending ? walks.OrderBy(x => x.LengthInKm) : walks.OrderByDescending(x => x.LengthInKm);
                }
            }

            //pagination
            var skipResults = (pageNumber - 1) * pageSize;

            return await walks.Skip(skipResults).Take(pageSize).ToListAsync();
            
        }

        public async Task<Walk?> GetByIdAsync(Guid id)
        {
            return await dbContext.Walks
                .Include(x => x.Difficulty)
                .Include("Region")
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
            var WalkDB = await dbContext.Walks.FirstOrDefaultAsync(x => x.Id == id);
            if (WalkDB == null) { return null; }

            //map
            WalkDB.Name = walk.Name;            
            WalkDB.LengthInKm = walk.LengthInKm;
            WalkDB.Description = walk.Description;            
            WalkDB.WalkImageUrl = walk.WalkImageUrl;
            WalkDB.RegionId = walk.RegionId;
            WalkDB.DifficultyId = walk.DifficultyId;

            await dbContext.SaveChangesAsync();
            return WalkDB;
        }
    }
}
