using Core.Domain;
using Egabinet.Data;
using Microsoft.EntityFrameworkCore;

namespace Core.Repositories
{
    public class TimeSheetRepository : ITimesheetRepository
    {
        private readonly ApplicationDbContext _dbContext;


        public TimeSheetRepository(ApplicationDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        public async Task<TimeSheet> AddAsync(TimeSheet timeSheet)
        {
            await _dbContext.AddAsync(timeSheet);
            await _dbContext.SaveChangesAsync();

            return timeSheet;
        }

        public IQueryable<TimeSheet> GetAllAsync()
        {
            return _dbContext.TimeSheet;
        }

        public IQueryable<TimeSheet> GetAllByPatientIdAsync(string id)
        {
            return _dbContext.TimeSheet.Where(t => t.Patient.UserId == id);
        }
        public IQueryable<TimeSheet> GetAllByDoctorIdAsync(string id)
        {
            return _dbContext.TimeSheet.Where(t => t.Doctor.UserId == id);
        }
        public async Task<TimeSheet> GetByIdAsync(string id)
        {
            return await _dbContext.TimeSheet.FirstOrDefaultAsync(u => u.Id == id);
        }


        public async Task RemoveAsync(string id)
        {
            var timeSheet = await GetByIdAsync(id);
            _dbContext.Remove(timeSheet);
            await _dbContext.SaveChangesAsync();

        }
    }
}
