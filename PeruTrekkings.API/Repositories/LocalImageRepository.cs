using PeruTrekkings.API.Data;
using PeruTrekkings.API.Models.Domain;

namespace PeruTrekkings.API.Repositories
{
    public class LocalImageRepository : IImageRepository
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly IHttpContextAccessor httpContextAccessor;
        private readonly PeruTrekkingsDbContext dbContext;

        public LocalImageRepository(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, PeruTrekkingsDbContext dbContext)
        {
            this.webHostEnvironment = webHostEnvironment;
            this.httpContextAccessor = httpContextAccessor;
            this.dbContext = dbContext;
        }


        public async Task<Image> Upload(Image image)
        {
            var localFilePath = Path.Combine(webHostEnvironment.ContentRootPath, "Images", $"{image.FileName}{image.FileExtension}");
            using var stream = new FileStream(localFilePath, FileMode.Create);
            await image.File.CopyToAsync(stream);

            var httpRequest = httpContextAccessor.HttpContext.Request;
            var urlFilePath = $"{httpRequest.Scheme}://{httpRequest.Host}{httpRequest.PathBase}/Images/{image.FileName}{image.FileExtension}";

            image.FilePath = urlFilePath;

            //Add image to Images table
            await dbContext.Images.AddAsync(image);
            await dbContext.SaveChangesAsync();

            return image;
        }
    }
}
