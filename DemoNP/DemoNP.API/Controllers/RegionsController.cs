using AutoMapper;
using DemoNP.API.Models.Domain;
using DemoNP.API.Models.DTO;
using DemoNP.API.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace DemoNP.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RegionsController : Controller
    {
        private readonly IRegionRepository regionRepository;
        private readonly IMapper mapper;

        public RegionsController(IRegionRepository regionRepository, IMapper mapper)
        {
            this.regionRepository = regionRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRegionsAsync()
        {
            var regions = await regionRepository.GetAllAsync();
            
            var regionsDTO = mapper.Map<List<RegionDto>>(regions);
            return Ok(regionsDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetRegionsAsync")]
        public async Task<IActionResult> GetRegionsAsync(Guid id)
        {
            var region = await regionRepository.GetAsync(id);
            if(region == null)
            {
                return NotFound();
            }
            var regionDTO = mapper.Map<RegionDto>(region);
            return Ok(regionDTO);
        }

        [HttpPost]
        public async Task<IActionResult> AddRegionsAsync(AddRegionRequest addRegionRequest)
        {
            //Request to Domain
            var region = new Region()
            {
                Code = addRegionRequest.Code,
                Name = addRegionRequest.Name,
                Area = addRegionRequest.Area,
                Lat = addRegionRequest.Lat,
                Long = addRegionRequest.Long,
                Population = addRegionRequest.Population
            };            
            //Pass detail to Repository
            region = await regionRepository.AddAsync(region);

            //Convert back to Dto
            var regionDTO = mapper.Map<RegionDto>(region);
            return CreatedAtAction(nameof(GetRegionsAsync), new { id = regionDTO.Id }, regionDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        public async Task<IActionResult> DeleteRegionsAsync(Guid id)
        {
            //Get region from db
            var region = await regionRepository.DeleteAsync(id);
            if (region == null)
            {
                return NotFound();
            }
            var regionDTO = mapper.Map<RegionDto>(region);
            return Ok(regionDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        public async Task<IActionResult> UpdateRegionsAsync([FromRoute] Guid id, [FromBody] UpdateRegionRequest updateRegionRequest)
        {
            //convert update to domain
            var region = new Region()
            {
                Code = updateRegionRequest.Code,
                Name = updateRegionRequest.Name,
                Area = updateRegionRequest.Area,
                Lat = updateRegionRequest.Lat,
                Long = updateRegionRequest.Long,
                Population = updateRegionRequest.Population
            };
            region = await regionRepository.UpdateAsync(id, region);
            if (region == null)
            {
                return NotFound();
            }
            var regionDTO = mapper.Map<RegionDto>(region);
            return Ok(regionDTO);
        }
    }
} 
