using Core.Domain;
using Egabinet.Data;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {
        private readonly ApplicationDbContext _dbContext;


        public DoctorRepository(ApplicationDbContext _dbContext)
        {
            this._dbContext = _dbContext;

        }


        public async Task<Doctor> AddAsync(Doctor doctor)
        {
            await _dbContext.AddAsync(doctor);
            await _dbContext.SaveChangesAsync();

            return doctor;
        }

        public async Task<IEnumerable<Doctor>> GetAllAsync()
        {
            return await _dbContext.Doctor.ToListAsync();
        }

        public async Task<Doctor> GetByNameAsync(string userName)
        {
            return await _dbContext.Doctor.FirstOrDefaultAsync(u => u.User.UserName == userName);
        }
        public async Task<Doctor> GetByIdAsync(string id)
        {
            return await _dbContext.Doctor.FirstOrDefaultAsync(u => u.Id == id);
        }


        public async Task RemoveAsync(string id)
        {
            var doctor = await GetByIdAsync(id);
            _dbContext.Remove(doctor);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<Doctor> UpdateAsync(Doctor doctor)
        {
            _dbContext.Update(doctor);
            await _dbContext.SaveChangesAsync();

            return doctor;
        }
    }
}
