using PeruTrekkings.API.Models.Domain;
using AutoMapper;
using PeruTrekkings.API.Models.DTO.RegionDTOs;
using PeruTrekkings.API.Models.DTO.WalkDTOs;
using PeruTrekkings.API.Models.DTO;

namespace PeruTrekkings.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            
            CreateMap<Region, RegionDTO>().ReverseMap();
            CreateMap<AddRegionDTO, Region>().ReverseMap();
            CreateMap<UpdateRegionDTO, Region>().ReverseMap();
            CreateMap<AddWalkDTO, Walk>().ReverseMap();
            CreateMap<Walk, WalkDto>().ReverseMap();
            CreateMap<Difficulty, DifficultyDto>().ReverseMap();


        }
    }
}
