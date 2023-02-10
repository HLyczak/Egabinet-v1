using Core.Domain;

namespace Core.Repositories
{
    public interface IPatientRepository
    {
        public Task<Patient> GetByNameAsync(string name);
        public Task<Patient> GetByIdAsync(string id);
        public Task<IEnumerable<Patient>> GetAllAsync();
        public Task RemoveAsync(string id);
        public Task<Patient> AddAsync(Patient patient);
        public Task<Patient> UpdateAsync(Patient patient);
    }
}
