using DemoNP.API.Models.Domain;

namespace DemoNP.API.Repositories
{
    public interface IRegionRepository
    {
        Task<IEnumerable<Region>> GetAllAsync();
    }
}
