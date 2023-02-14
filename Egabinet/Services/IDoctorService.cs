using Egabinet.Models;
using Microsoft.AspNetCore.Identity;

namespace Egabinet.Services
{
    public interface IDoctorService
    {
        public Task<IdentityUser> GetUser(string name);
        public Task<UpdateDoctorViewModel> GetUpdateDoctorViewModel(string name);
        public Task UpdateDoctorAsync(UpdateDoctorViewModel model);
        public Task<List<TimeSheetViewModel>> ShowTimesheet(string name);
        public Task<DoctorViewModel> GetDoctorAsync(string name);


    }
}
