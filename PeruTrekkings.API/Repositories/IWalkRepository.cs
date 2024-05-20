using PeruTrekkings.API.Models.Domain;

namespace PeruTrekkings.API.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk> CreateAsync(Walk walk);
    }
}
