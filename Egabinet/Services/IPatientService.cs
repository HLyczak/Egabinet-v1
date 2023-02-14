using Egabinet.Models;
using Microsoft.AspNetCore.Identity;

namespace Egabinet.Services
{
    public interface IPatientService
    {
        public Task<IdentityUser> GetUser(string name);
        public Task<List<TimeSheetViewModel>> ShowTimesheet(string name);
        public Task DeleteVisitAsync(string id);
        public Task<UpdatePatientViewModel> GetUpdatePatientViewModel(string name);
        public Task UpdatePatientAsync(UpdatePatientViewModel model);
        public Task<PatientViewModel> GetPatientAsync(string name);

    }
}
