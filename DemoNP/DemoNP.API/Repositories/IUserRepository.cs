using DemoNP.API.Models.Domain;

namespace DemoNP.API.Repositories
{
    public interface IUserRepository
    {
        Task<User> AuthenticateAsync(string username, string password);
    }
}
