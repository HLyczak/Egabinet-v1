using Core.Domain;

namespace Core.Repositories
{
    public interface ITimesheetRepository
    {
        public Task<TimeSheet> GetByIdAsync(string id);
        public IQueryable<TimeSheet> GetAllAsync();
        public IQueryable<TimeSheet> GetAllByPatientIdAsync(string id);
        public IQueryable<TimeSheet> GetAllByDoctorIdAsync(string id);
        public Task RemoveAsync(string id);
        public Task<TimeSheet> AddAsync(TimeSheet timeSheet);

    }
}
