namespace Egabinet.Services
{
    public interface IUserService
    {
        public Task<string> GetUserRole(string? name);
    }
}
