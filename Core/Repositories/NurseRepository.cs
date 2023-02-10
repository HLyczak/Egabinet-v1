using Core.Domain;
using Egabinet.Data;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories
{
    public class NurseRepository : INurseRepository
    {
        private readonly ApplicationDbContext _dbContext;


        public NurseRepository(ApplicationDbContext _dbContext)
        {
            this._dbContext = _dbContext;

        }


        public async Task<Nurse> AddAsync(Nurse nurse)
        {
            await _dbContext.AddAsync(nurse);
            await _dbContext.SaveChangesAsync();

            return nurse;
        }

        public async Task<IEnumerable<Nurse>> GetAllAsync()
        {
            return await _dbContext.Nurse.ToListAsync();
        }

        public async Task<Nurse> GetByNameAsync(string userName)
        {
            return await _dbContext.Nurse.FirstOrDefaultAsync(u => u.User.UserName == userName);
        }
        public async Task<Nurse> GetByIdAsync(string id)
        {
            return await _dbContext.Nurse.FirstOrDefaultAsync(u => u.Id == id);
        }


        public async Task RemoveAsync(string id)
        {
            var nurse = await GetByIdAsync(id);
            _dbContext.Remove(nurse);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<Nurse> UpdateAsync(Nurse nurse)
        {
            _dbContext.Update(nurse);
            await _dbContext.SaveChangesAsync();

            return nurse;
        }
    }
}
