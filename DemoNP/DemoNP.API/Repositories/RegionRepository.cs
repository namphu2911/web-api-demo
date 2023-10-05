using DemoNP.API.Data;
using DemoNP.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DemoNP.API.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly NPDbContext nPDbContext;
        public RegionRepository(NPDbContext nPDbContext)
        {
            this.nPDbContext = nPDbContext;
        }
        public async Task<IEnumerable<Region>> GetAllAsync()
        {
            return await nPDbContext.Regions.ToListAsync();
        }
    }
}
