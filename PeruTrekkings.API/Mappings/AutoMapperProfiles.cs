using PeruTrekkings.API.Models.Domain;
using PeruTrekkings.API.Models.DTO;
using AutoMapper;

namespace PeruTrekkings.API.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            
            CreateMap<Region, RegionDTO>().ReverseMap();
            CreateMap<AddRegionDTO, Region>().ReverseMap();
            CreateMap<UpdateRegionDTO, Region>().ReverseMap();


        }
    }
}
