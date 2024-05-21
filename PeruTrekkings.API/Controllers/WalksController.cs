using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
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
        public async Task<IActionResult> Create([FromBody] AddWalkDTO addWalkDTO)
        {
            if (ModelState.IsValid)
            {
                var walkModel = mapper.Map<Walk>(addWalkDTO);
                await walkRepository.CreateAsync(walkModel);
                //map domainModel to DTO
                return Ok(mapper.Map<WalkDto>(walkModel));
            }
            else
            {
                return BadRequest(ModelState);
            }

           
        }

        //Get all Walks
        [HttpGet]
        public async Task<IActionResult> GetAll() {
            var walksModel= await walkRepository.GetAllAsync();
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
        public async Task<IActionResult> Update([FromRoute] Guid id, UpdateWalkDto updateWalkDto) 
        {
            if (ModelState.IsValid)
            {
                //map updateWalk to DomModel
                var walkDomModel = mapper.Map<Walk>(updateWalkDto);
                walkDomModel = await walkRepository.UpdateAsync(id, walkDomModel);

                if (walkDomModel == null) { return NotFound(); }
                //map Model to dto
                return Ok(mapper.Map<WalkDto>(walkDomModel));
            }
            else
            {
                return BadRequest(ModelState);
            }           
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
