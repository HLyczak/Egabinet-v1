using Egabinet.Models;
using Microsoft.AspNetCore.Identity;

namespace Egabinet.Services
{
    public interface INurseService
    {
        public Task<IdentityUser> GetUser(string name);

        public Task<IEnumerable<ShowUsersViewModel>> ShowUsers();
        public Task<List<TimeSheetViewModel>> ShowTimesheet();
        public Task<AddVisitViewModel> GetAddVisitViewModel();
        public Task AddVisit(AddVisitViewModel model);
        public Task<UpdateNurseViewModel> GetUpdateNurseViewModel(string name);
        public Task UpdateNurseAsync(UpdateNurseViewModel model);
        public Task DeleteVisitAsync(string id);
        public Task<NurseViewModel> GetNurseAsync(string name);


    }
}
