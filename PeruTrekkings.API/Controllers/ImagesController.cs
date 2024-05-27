using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeruTrekkings.API.Models.DTO;

namespace PeruTrekkings.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImagesController : ControllerBase
    {

        //Post:  /api/Images/Upload
        [HttpPost]
        [Route("Upload")]
        public async Task<IActionResult> Upload([FromForm] ImageUpDto imageRequest)
        {
            ValidateFileUpload(imageRequest);
            if (ModelState.IsValid) 
            {
                //User repository to upload image
            }
            return BadRequest(ModelState);
        }

        private void ValidateFileUpload (ImageUpDto imageRequest)
        {
            var allowedExtensions = new string[] { ".jpg", ".jpeg", ".png" };
            if (allowedExtensions.Contains(Path.GetExtension(imageRequest.File.FileName))) 
            {
                ModelState.AddModelError("file", "Unsupported file extension");
            }
            if (imageRequest.File.Length > 10485760) //10 MB
            {
                ModelState.AddModelError("file", "File size more than 10MB, please upload less");
            }
        }

    }
}
