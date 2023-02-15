using Core.Repositories;

namespace Egabinet.Services
{
    public class UserService : IUserService
    {

        private readonly IUserRepository userRepository;


        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<string> GetUserRole(string? name)
        {
            return string.IsNullOrWhiteSpace(name) ? "" : await userRepository.GetUserRoleAsync(name);
        }
    }
}
