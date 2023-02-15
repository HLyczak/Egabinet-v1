using Egabinet.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;


        public UserRepository(ApplicationDbContext _dbContext)
        {
            this._dbContext = _dbContext;

        }

        public async Task<IdentityUser> GetByNameAsync(string userName)
        {
            return await _dbContext.Users.FirstOrDefaultAsync(u => u.UserName == userName);
        }

        public async Task<string> GetUserRoleAsync(string userName)
        {
            if (await _dbContext.Nurse.AnyAsync(n => n.User.UserName == userName))
            {
                return "nurse";
            };
            if (await _dbContext.Patient.AnyAsync(n => n.User.UserName == userName))
            {
                return "patient";
            };
            if (await _dbContext.Doctor.AnyAsync(n => n.User.UserName == userName))
            {
                return "doctor";
            };

            return "";
        }
    }
}
