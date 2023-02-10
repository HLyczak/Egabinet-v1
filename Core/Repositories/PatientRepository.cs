using Core.Domain;
using Egabinet.Data;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _dbContext;


        public PatientRepository(ApplicationDbContext _dbContext)
        {
            this._dbContext = _dbContext;

        }


        public async Task<Patient> AddAsync(Patient patient)
        {
            await _dbContext.AddAsync(patient);
            await _dbContext.SaveChangesAsync();

            return patient;
        }

        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            return await _dbContext.Patient.ToListAsync();
        }


        public async Task<Patient> GetByNameAsync(string userName)
        {
            return await _dbContext.Patient.FirstOrDefaultAsync(u => u.User.UserName == userName);
        }
        public async Task<Patient> GetByIdAsync(string id)
        {
            return await _dbContext.Patient.FirstOrDefaultAsync(u => u.Id == id);
        }


        public async Task RemoveAsync(string id)
        {
            var patient = await GetByIdAsync(id);
            _dbContext.Remove(patient);
            await _dbContext.SaveChangesAsync();

        }

        public async Task<Patient> UpdateAsync(Patient patient)
        {
            _dbContext.Update(patient);
            await _dbContext.SaveChangesAsync();

            return patient;
        }
    }
}
