﻿using PeruTrekkings.API.Models.Domain;
using PeruTrekkings.API.Models.DTO.RegionDTOs;

namespace PeruTrekkings.API.Models.DTO.WalkDTOs
{
    public class WalkDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public string Description { get; set; }

        public double LengthInKm { get; set; }

        public string? WalkImageUrl { get; set; }

        public Guid DifficultyId { get; set; }
        public Guid RegionId { get; set; }

        //navigation props that will arrive thanks to guid props

        public RegionDTO Region { get; set; }
        public DifficultyDto Difficulty { get; set; }
         
    }
}
