using PeruTrekkings.API.Models.Domain;

namespace PeruTrekkings.API.Repositories
{
    public interface IRegionRepository
    {
        Task<List<Region>> GetAllAsync();
        Task<Region?> GetByIdAsync(Guid id);
        Task<Region> CreateAsync(Region region);
        Task<Region> UpdateAsync(Guid id, Region region);
        Task<Region?> DeleteAsync(Guid id);

    }
}
