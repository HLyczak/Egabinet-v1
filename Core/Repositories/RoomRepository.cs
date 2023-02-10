using Core.Domain;
using Egabinet.Data;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories
{
    public class RoomRepository : IRoomRepository
    {
        private readonly ApplicationDbContext _dbContext;


        public RoomRepository(ApplicationDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        public async Task<Room> GetByIdAsync(string id)
        {
            return await _dbContext.Room.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<IEnumerable<Room>> GetAllAsync()
        {
            return await _dbContext.Room.ToListAsync();
        }


    }
}
