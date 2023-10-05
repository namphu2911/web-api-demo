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

        public async Task<Region> GetAsync(Guid id)
        {
            return await nPDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Region> AddAsync(Region region)
        {
            region.Id = Guid.NewGuid();
            await nPDbContext.AddAsync(region);
            await nPDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> DeleteAsync(Guid id)
        {
            var region = await nPDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if(region == null)
            {
                return null;
            }
            nPDbContext.Regions.Remove(region);
            await nPDbContext.SaveChangesAsync();
            return region;
        }

        public async Task<Region> UpdateAsync(Guid id, Region region)
        {
            var existingRegion = await nPDbContext.Regions.FirstOrDefaultAsync(x => x.Id == id);
            if (existingRegion == null)
            {
                return null;
            }
            existingRegion.Code = region.Code;
            existingRegion.Name = region.Name;
            existingRegion.Area = region.Area;
            existingRegion.Lat = region.Lat;
            existingRegion.Long = region.Long;
            existingRegion.Population = region.Population;

            await nPDbContext.SaveChangesAsync();
            return existingRegion;
        }

    }
}
