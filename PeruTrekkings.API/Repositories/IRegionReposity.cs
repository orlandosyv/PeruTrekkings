using PeruTrekkings.API.Models.Domain;

namespace PeruTrekkings.API.Repositories
{
    public interface IRegionReposity
    {
        Task<List<Region>> GetAllAsync();
    }
}
