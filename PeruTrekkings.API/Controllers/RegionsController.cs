using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using PeruTrekkings.API.Data;
using PeruTrekkings.API.Models.Domain;
using PeruTrekkings.API.Models.DTO;
using PeruTrekkings.API.Repositories;
using System.Runtime.CompilerServices;

namespace PeruTrekkings.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegionsController : ControllerBase
    {
        private readonly PeruTrekkingsDbContext dbContext;
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(PeruTrekkingsDbContext dbContext, IRegionRepository regionReposity,
            IMapper mapper)
        {
            this.dbContext = dbContext;
            this.regionRepository = regionReposity;
            this.mapper = mapper;
        }

        //GetAll 
        //GET: https://localhost:{portnumber}/api/regions
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            //Get data from DB
            var regionsDomain = await regionRepository.GetAllAsync();
            //Map Domain Models To DTOs

            //var regionsDTO = new List<RegionDTO>();
            //foreach (var region in regionsDomain)
            //{
            //    regionsDTO.Add(new RegionDTO()
            //    {
            //        Id = region.Id,
            //        Name = region.Name,
            //        Code = region.Code,
            //        RegionImageUrl = region.RegionImageUrl,
            //    });
            //}
            var regionsDTO = mapper.Map<List<RegionDTO>>(regionsDomain);
            //Return DTO
            return Ok(regionsDTO);
        }

        //Get single Region
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute]Guid id)
        {
            var regionModel = await regionRepository.GetByIdAsync(id);
            if (regionModel == null) { return NotFound(); }

            //map - convert our modelDomain to modelDto
            //var regionDto = new RegionDTO()
            //{
            //    Id = regionModel.Id,
            //    Name = regionModel.Name,
            //    Code = regionModel.Code,
            //    RegionImageUrl = regionModel.RegionImageUrl,
            //};

            return Ok(mapper.Map<RegionDTO>(regionModel));
        }

        //Post to create a new region
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] AddRegionDTO addRegionDTO)
        {
            //Map or Convert DTO to model
            var regionModel = mapper.Map<Region>(addRegionDTO);
            //var regionModel = new Region
            //{
            //    Code = addRegionDTO.Code,
            //    RegionImageUrl = addRegionDTO.RegionImageUrl,
            //    Name = addRegionDTO.Name,
            //};

            //use Domain model to create region            
            regionModel = await regionRepository.CreateAsync(regionModel);            

            //map
            //var regionDTO = new RegionDTO
            //{
            //    Id = regionModel.Id,
            //    Name = regionModel.Name,
            //    Code = regionModel.Code,
            //    RegionImageUrl = regionModel.RegionImageUrl,
            //};
            var regionDTO = mapper.Map<RegionDTO>(regionModel);

            return CreatedAtAction(nameof(GetById), new { id = regionModel.Id }, regionDTO);
        }

        //Update
        [HttpPut]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Update([FromRoute]Guid id, [FromBody] UpdateRegionDTO updateRegionDTO) 
        {
            //Map region to DTO Model
            var regionModel = mapper.Map<Region>(updateRegionDTO);
            //var regionModel = new Region
            //{
            //    Code = updateRegionDTO.Code,
            //    Name = updateRegionDTO.Name,
            //    RegionImageUrl = updateRegionDTO.RegionImageUrl,
            //};

            regionModel = await regionRepository.UpdateAsync(id, regionModel);
            //var regionModel = await dbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (regionModel == null) { return NotFound(); }

            //map            
            //regionModel.Code = updateRegionDTO.Code;
            //regionModel.Name = updateRegionDTO.Name;
            //regionModel.RegionImageUrl = updateRegionDTO.RegionImageUrl;            
            //await dbContext.SaveChangesAsync();

            //convert regionModel to regionDTO
            var regionDTO = mapper.Map<RegionDTO> (regionModel);
            //var regionDTO = new RegionDTO
            //{
            //    Id = regionModel.Id,
            //    Name = regionModel.Name,
            //    Code = regionModel.Code,
            //    RegionImageUrl = regionModel.RegionImageUrl,
            //};

            return Ok(regionDTO);
        }

        //DELETE
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete([FromRoute]Guid id) 
        {
            var regionModel = await regionRepository.DeleteAsync(id);
            if (regionModel == null) { return NotFound(); }            

            //return deleted region, map regionModel to a new regionDTO
            //var regionDTO = new RegionDTO
            //{
            //    Id = regionModel.Id,
            //    Name = regionModel.Name,
            //    Code = regionModel.Code,
            //    RegionImageUrl = regionModel.RegionImageUrl,
            //};

            return Ok(mapper.Map<RegionDTO>(regionModel));
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