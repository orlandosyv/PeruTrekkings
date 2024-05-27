using PeruTrekkings.API.Models.Domain;

namespace PeruTrekkings.API.Repositories
{
    public interface IImageRepository
    {
        Task<Image> Upload(Image image);
      
    }
}
