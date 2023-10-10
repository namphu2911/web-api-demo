using DemoNP.API.Models.Domain;

namespace DemoNP.API.Repositories
{
    public interface ITokenHandler
    {
        Task<string> CreateTokenAsync(User user);
    }
}
