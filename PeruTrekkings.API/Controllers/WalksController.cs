using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PeruTrekkings.API.Models.Domain;
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
            var walkModel = mapper.Map<Walk>(addWalkDTO);
            await walkRepository.CreateAsync(walkModel);

            //map domainModel to DTO
            return Ok(mapper.Map<WalkDto>(walkModel));
        }
    }
}
