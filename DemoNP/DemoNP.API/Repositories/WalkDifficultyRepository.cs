using DemoNP.API.Data;
using DemoNP.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DemoNP.API.Repositories
{
    public class WalkDifficultyRepository : IWalkDifficultyRepository
    {
        private readonly NPDbContext nPDbContext;
        public WalkDifficultyRepository(NPDbContext nPDbContext)
        {
            this.nPDbContext = nPDbContext;
        }

        public async Task<IEnumerable<WalkDifficulty>> GetAllAsync()
        {
            return await nPDbContext.WalkDifficulties
                .ToListAsync();
        }

        public async Task<WalkDifficulty> GetAsync(Guid id)
        {
            return await nPDbContext.WalkDifficulties
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<WalkDifficulty> AddAsync(WalkDifficulty walkDifficulty)
        {
            walkDifficulty.Id = Guid.NewGuid();
            await nPDbContext.AddAsync(walkDifficulty);
            await nPDbContext.SaveChangesAsync();
            return walkDifficulty;
        }

        public async Task<WalkDifficulty> UpdateAsync(Guid id, WalkDifficulty walkDifficulty)
        {
            var existingWalkDifficulty = await nPDbContext.WalkDifficulties.FirstOrDefaultAsync(x => x.Id == id);
            if (existingWalkDifficulty == null)
            {
                return null;
            }
            existingWalkDifficulty.Code = walkDifficulty.Code;

            await nPDbContext.SaveChangesAsync();
            return existingWalkDifficulty;
        }

        public async Task<WalkDifficulty> DeleteAsync(Guid id)
        {
            var walkDifficulty = await nPDbContext.WalkDifficulties.FirstOrDefaultAsync(x => x.Id == id);
            if (walkDifficulty == null)
            {
                return null;
            }
            nPDbContext.WalkDifficulties.Remove(walkDifficulty);
            await nPDbContext.SaveChangesAsync();
            return walkDifficulty;
        }
    }
}
