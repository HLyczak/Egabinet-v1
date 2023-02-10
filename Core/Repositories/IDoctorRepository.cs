using Core.Domain;

namespace Core.Repositories
{
    public interface IDoctorRepository
    {
        public Task<Doctor> GetByNameAsync(string name);
        public Task<Doctor> GetByIdAsync(string id);
        public Task<IEnumerable<Doctor>> GetAllAsync();
        public Task RemoveAsync(string id);
        public Task<Doctor> AddAsync(Doctor doctor);
        public Task<Doctor> UpdateAsync(Doctor doctor);
    }
}
