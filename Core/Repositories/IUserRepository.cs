using Microsoft.AspNetCore.Identity;

namespace Core.Repositories
{
    public interface IUserRepository
    {
        public Task<IdentityUser> GetByNameAsync(string name);
    }
}
