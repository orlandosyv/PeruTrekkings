using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeruTrekkings.API.Models.Domain;
using PeruTrekkings.API.Models.DTO;
using PeruTrekkings.API.Repositories;

namespace PeruTrekkings.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly IImageRepository imageRepository;

        public ImagesController(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }

        //Post:  /api/Images/Upload
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUpDto requestImage)
        {
            ValidateFileUpload(requestImage);
            if (ModelState.IsValid) 
            {
                //Dto to dom Model
                var imageModel = new Image
                {
                    File = requestImage.File,
                    FileExtension = Path.GetExtension(requestImage.File.FileName),
                    FileSizeInBytes = requestImage.File.Length,
                    FileName = requestImage.FileName,
                    FileDescription = requestImage.FileDescription,
                };

                //User repository to upload image
                await imageRepository.Upload(imageModel);
                return Ok(imageModel);
            }

            return BadRequest(ModelState);
        }

        private void ValidateFileUpload (ImageUpDto requestImage)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };
            var imageExtension = Path.GetExtension(requestImage.File.FileName);
            if (!allowedExtensions.Contains(imageExtension)) 
            {
                ModelState.AddModelError("file", "Unsupported file extension");
            }
            if (requestImage.File.Length > 10485760) //10 MB
            {
                ModelState.AddModelError("file", "File size more than 10MB, please upload less");
            }
        }

    }
}
