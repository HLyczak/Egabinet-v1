using Core.Domain;

namespace Core.Repositories
{
    public interface IRoomRepository
    {
        public Task<Room> GetByIdAsync(string id);
        public Task<IEnumerable<Room>> GetAllAsync();
    }
}
