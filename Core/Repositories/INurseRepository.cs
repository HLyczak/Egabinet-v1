using Core.Domain;

namespace Core.Repositories
{
    public interface INurseRepository
    {
        public Task<Nurse> GetByNameAsync(string name);
        public Task<Nurse> GetByIdAsync(string id);
        public Task<IEnumerable<Nurse>> GetAllAsync();
        public Task RemoveAsync(string id);
        public Task<Nurse> AddAsync(Nurse nurse);
        public Task<Nurse> UpdateAsync(Nurse nurse);
    }
}
