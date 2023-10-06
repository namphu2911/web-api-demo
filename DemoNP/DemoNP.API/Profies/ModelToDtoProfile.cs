using AutoMapper;
using DemoNP.API.Models.Domain;
using DemoNP.API.Models.DTO;

namespace DemoNP.API.Profies
{
    public class ModelToDtoProfile : Profile
    {
        public ModelToDtoProfile()
        {
            CreateMap<Region, RegionDto>()
                .ReverseMap();
            CreateMap<Walk, WalkDto>()
                .ReverseMap();
            CreateMap<WalkDifficulty, WalkDifficultyDto>()
                .ReverseMap();
        }
    }
}
