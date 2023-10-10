using DemoNP.API.Data;
using DemoNP.API.Models.Domain;
using Microsoft.EntityFrameworkCore;

namespace DemoNP.API.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly NPDbContext nPDbContext;

        public UserRepository(NPDbContext nPDbContext)
        {
            this.nPDbContext = nPDbContext;
        }


        public async Task<User> AuthenticateAsync(string username, string password)
        {
            var user = await nPDbContext.Users
                .FirstOrDefaultAsync(x => x.Username.ToLower() == username.ToLower() && x.Password == password);

            if (user == null)
            {
                return null;
            }

            var userRoles = await nPDbContext.Users_Roles.Where(x => x.UserId == user.Id).ToListAsync();

            if (userRoles.Any())
            {
                user.Roles = new List<string>();
                foreach (var userRole in userRoles)
                {
                    var role = await nPDbContext.Roles.FirstOrDefaultAsync(x => x.Id == userRole.RoleId);
                    if (role != null)
                    {
                        user.Roles.Add(role.Name);
                    }
                }
            }

            user.Password = null;
            return user;
        }
    }
}
