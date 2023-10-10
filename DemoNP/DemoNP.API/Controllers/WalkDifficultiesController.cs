using AutoMapper;
using DemoNP.API.Models.Domain;
using DemoNP.API.Models.DTO;
using DemoNP.API.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DemoNP.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WalkDifficultiesController : Controller
    {
        private readonly IWalkDifficultyRepository walkDifficultyRepository;
        private readonly IMapper mapper;
        public WalkDifficultiesController(IWalkDifficultyRepository walkDifficultyRepository, IMapper mapper)
        {
            this.walkDifficultyRepository = walkDifficultyRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetAllWalkDifficultiesAsync()
        {
            var walkDifficulties = await walkDifficultyRepository.GetAllAsync();

            var walkDifficultiesDTO = mapper.Map<List<WalkDifficultyDto>>(walkDifficulties);
            return Ok(walkDifficultiesDTO);
        }

        [HttpGet]
        [Route("{id:guid}")]
        [ActionName("GetWalkDifficultiesAsync")]
        [Authorize(Roles = "reader")]
        public async Task<IActionResult> GetWalkDifficultiesAsync(Guid id)
        {
            var walkDifficulty = await walkDifficultyRepository.GetAsync(id);
            if (walkDifficulty == null)
            {
                return NotFound();
            }
            var walkDifficultyDTO = mapper.Map<WalkDifficultyDto>(walkDifficulty);
            return Ok(walkDifficultyDTO);
        }

        [HttpPost]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> AddWalkDifficultiesAsync(AddWalkDifficultyRequest addWalkDifficultyRequest)
        {
            // validate incoming request
            //if (!ValidateAddWalkDifficultyAsync(addWalkDifficultyRequest))
            //{
            //    return BadRequest(ModelState);
            //}
            //Request to Domain
            var walkDifficulty = new WalkDifficulty()
            {
                Code = addWalkDifficultyRequest.Code
            };
            //Pass detail to Repository
            walkDifficulty = await walkDifficultyRepository.AddAsync(walkDifficulty);

            //Convert back to Dto
            var walkDifficultyDTO = mapper.Map<WalkDifficultyDto>(walkDifficulty);
            return CreatedAtAction(nameof(GetWalkDifficultiesAsync), new { id = walkDifficultyDTO.Id }, walkDifficultyDTO);
        }

        [HttpPut]
        [Route("{id:guid}")]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> UpdateWalkDifficultiesAsync([FromRoute] Guid id, [FromBody] UpdateWalkDifficultyRequest updateWalkDifficultyRequest)
        {
            // Validate the incoming request
            //if (!ValidateUpdateWalkDifficultyAsync(updateWalkDifficultyRequest))
            //{
            //    return BadRequest(ModelState);
            //}
            //convert update to domain
            var walkDifficulty = new WalkDifficulty()
            {
                Code = updateWalkDifficultyRequest.Code
            };
            walkDifficulty = await walkDifficultyRepository.UpdateAsync(id, walkDifficulty);
            if (walkDifficulty == null)
            {
                return NotFound();
            }
            var walkDifficultyDTO = mapper.Map<WalkDifficultyDto>(walkDifficulty);
            return Ok(walkDifficultyDTO);
        }

        [HttpDelete]
        [Route("{id:guid}")]
        [Authorize(Roles = "writer")]
        public async Task<IActionResult> DeleteWalkDifficultiesAsync(Guid id)
        {
            //Get region from db
            var walkDifficulty = await walkDifficultyRepository.DeleteAsync(id);
            if (walkDifficulty == null)
            {
                return NotFound();
            }
            var walkDifficultyDTO = mapper.Map<WalkDifficultyDto>(walkDifficulty);
            return Ok(walkDifficultyDTO);
        }

        #region Private methods
        private bool ValidateAddWalkDifficultyAsync(AddWalkDifficultyRequest addWalkDifficultyRequest)
        {
            if (addWalkDifficultyRequest == null)
            {
                ModelState.AddModelError(nameof(addWalkDifficultyRequest),
                    $"{nameof(addWalkDifficultyRequest)} is required.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(addWalkDifficultyRequest.Code))
            {
                ModelState.AddModelError(nameof(addWalkDifficultyRequest.Code),
                    $"{nameof(addWalkDifficultyRequest.Code)} is required.");
            }

            if (ModelState.ErrorCount > 0)
            {
                return false;
            }

            return true;
        }

        private bool ValidateUpdateWalkDifficultyAsync(UpdateWalkDifficultyRequest updateWalkDifficultyRequest)
        {
            if (updateWalkDifficultyRequest == null)
            {
                ModelState.AddModelError(nameof(updateWalkDifficultyRequest),
                    $"{nameof(updateWalkDifficultyRequest)} is required.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(updateWalkDifficultyRequest.Code))
            {
                ModelState.AddModelError(nameof(updateWalkDifficultyRequest.Code),
                    $"{nameof(updateWalkDifficultyRequest.Code)} is required.");
            }

            if (ModelState.ErrorCount > 0)
            {
                return false;
            }

            return true;
        }
        #endregion
    }
}
