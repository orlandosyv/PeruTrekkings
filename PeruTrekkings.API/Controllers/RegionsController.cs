using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using PeruTrekkings.API.Data;
using PeruTrekkings.API.Models.Domain;
using PeruTrekkings.API.Models.DTO;

namespace PeruTrekkings.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly PeruTrekkingsDbContext dbContext;
        public RegionsController(PeruTrekkingsDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        //GetAll 
        //GET: https://localhost:{portnumber}/api/regions
        [HttpGet]
        public IActionResult GetAll() 
        {
            //Get data from DB
            var regionsDomain = dbContext.Regions.ToList();
            //Map Domain Models To DTOs
            var regionsDTO = new List<RegionDTO>();
            foreach (var region in regionsDomain)
            {
                regionsDTO.Add(new RegionDTO()
                {
                    Id = region.Id,
                    Name = region.Name,
                    Code = region.Code,
                    RegionImageUrl = region.RegionImageUrl,
                });
            }

            //Return DTO
            return Ok(regionsDTO);            
        }

        //Get single Region
        [HttpGet]
        [Route("{id:Guid}")]
        public IActionResult GetById(Guid id)
        {
            var regionDomain = dbContext.Regions.FirstOrDefault(r => r.Id == id);
            if (regionDomain == null) { return NotFound(); }

            //map - convert our modelDomain to modelDto
            var regionDto = new RegionDTO()
            {
                Id = regionDomain.Id,
                Name = regionDomain.Name,
                Code = regionDomain.Code,
                RegionImageUrl = regionDomain.RegionImageUrl,
            };

            return Ok(regionDto);
        }

        //Post to create a new region
        [HttpPost]
        public IActionResult Create([FromBody] AddRegionDTO addRegionDTO) 
        {
            //Convert DTO to model
            var regionModel = new Region
            {
                Code = addRegionDTO.Code,
                RegionImageUrl = addRegionDTO.RegionImageUrl,
                Name = addRegionDTO.Name,
            };

            //use Domain model to create region
            dbContext.Regions.Add(regionModel);
            dbContext.SaveChanges(); //executes the changes and saves in DB

            //map
            var regionDTO = new RegionDTO
            {
                Id = regionModel.Id,
                Name = regionModel.Name,
                Code = regionModel.Code,
                RegionImageUrl = regionModel.RegionImageUrl,
            };

            return CreatedAtAction(nameof(GetById), new { id = regionModel.Id }, regionDTO);
        }
    }
}


//var regions = new List<Region>
//{
//    new Region { Id = Guid.NewGuid(), Name = "Ruta Inka", Code = "RIK",
//        RegionImageUrl = "https://images.unsplash.com/photo-1519607482862-4e767329ce8b"},
//    new Region { Id = Guid.NewGuid(),Name = "Ruta Arequipa", Code = "AQP",
//        RegionImageUrl = "https://images.unsplash.com/photo-1611154046036-cd91e50978be"}
//};