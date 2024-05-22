using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PeruTrekkings.API.CustomActionFilter;
using PeruTrekkings.API.Models.Domain;
using PeruTrekkings.API.Models.DTO.RegionDTOs;
using PeruTrekkings.API.Models.DTO.WalkDTOs;
using PeruTrekkings.API.Repositories;

namespace PeruTrekkings.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WalksController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IWalkRepository walkRepository;

        public WalksController(IMapper mapper, IWalkRepository walkRepository)
        {
            this.mapper = mapper;
            this.walkRepository = walkRepository;
        }

        //Create walk
        [HttpPost]
        [ValidateModel]
        public async Task<IActionResult> Create([FromBody] AddWalkDTO addWalkDTO)
        {
            var walkModel = mapper.Map<Walk>(addWalkDTO);
            await walkRepository.CreateAsync(walkModel);
            //map domainModel to DTO
            return Ok(mapper.Map<WalkDto>(walkModel));
        }

        //Get all Walks
        //GET: /api/walks?filterOn=Name&filterQuery=Track&sortBy=Name&isAscending=true
        [HttpGet]
        public async Task<IActionResult> GetAll (
            [FromQuery] string? filterOn, 
            [FromQuery] string? filterQuery,
            [FromQuery] string? sortBy,
            [FromQuery] bool? isAscending
            ) 
        {
            var walksModel= await walkRepository.GetAllAsync(filterOn, filterQuery,sortBy, isAscending ?? true);
            //map
            return Ok(mapper.Map<List<WalkDto>>(walksModel));
        }

        //get by id
        [HttpGet]
        [Route("{id:Guid}")]
        public async Task<IActionResult> GetById([FromRoute] Guid id)
        {
            var WalkDomModel = await walkRepository.GetByIdAsync(id);
            if (WalkDomModel == null) { return NotFound(); }
            //map domainModel to DTO
            return Ok(mapper.Map<WalkDto>(WalkDomModel));
        }

        //Update PUT
        [HttpPut]
        [Route("{id:Guid}")]
        [ValidateModel]
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateWalkDto updateWalkDto) 
        {           
                //map updateWalk to DomModel
                var walkDomModel = mapper.Map<Walk>(updateWalkDto);
                walkDomModel = await walkRepository.UpdateAsync(id, walkDomModel);

                if (walkDomModel == null) { return NotFound(); }
                //map Model to dto
                return Ok(mapper.Map<WalkDto>(walkDomModel));             
        }

        //Delete
        [HttpDelete]
        [Route("{id:Guid}")]
        public async Task<IActionResult> Delete(Guid id) 
        {
            var walkModel = await walkRepository.DeleteAsync(id);
            if (walkModel == null) { return NotFound(); }
            return Accepted(mapper.Map<WalkDto>(walkModel));            
        }
    }
}
