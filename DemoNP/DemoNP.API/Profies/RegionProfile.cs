using AutoMapper;
using DemoNP.API.Models.Domain;
using DemoNP.API.Models.DTO;

namespace DemoNP.API.Profies
{
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            CreateMap<Region, RegionDto>()
                .ReverseMap();
        }
    }
}
