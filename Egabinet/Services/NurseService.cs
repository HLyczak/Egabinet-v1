using Core.Domain;
using Core.Repositories;
using Egabinet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Egabinet.Services
{
    public class NurseService : INurseService
    {

        private readonly IUserRepository userRepository;
        private readonly INurseRepository nurseRepository;
        private readonly ITimesheetRepository timesheetRepository;
        private readonly IRoomRepository roomRepository;
        private readonly IPatientRepository patientRepository;
        private readonly IDoctorRepository doctorRepository;


        public NurseService(IUserRepository userRepository, INurseRepository nurseRepository, ITimesheetRepository timesheetRepository, IRoomRepository roomRepository, IPatientRepository patientRepository, IDoctorRepository doctorRepository)
        {
            this.userRepository = userRepository;
            this.nurseRepository = nurseRepository;
            this.timesheetRepository = timesheetRepository;
            this.roomRepository = roomRepository;
            this.patientRepository = patientRepository;
            this.doctorRepository = doctorRepository;
        }

        public async Task DeleteVisitAsync(string id)
        {
            TimeSheet visitToDelete = await timesheetRepository.GetByIdAsync(id);

            if (visitToDelete == null)
            {
                throw new Exception("Visit to delete does not exist");
            }
            await timesheetRepository.RemoveAsync(id);
        }

        public async Task AddVisit(AddVisitViewModel model)
        {
            TimeSheet timesheet = new TimeSheet()
            {
                DoctorId = model.SelectedDoctor,
                PatientId = model.SelectedPatient,
                Data = model.SelectedData,
                RoomId = model.SelectedRoom,
            };

            await timesheetRepository.AddAsync(timesheet);
        }

        public async Task<AddVisitViewModel> GetAddVisitViewModel()
        {
            Dictionary<string, SelectListGroup> doctordic = new Dictionary<string, SelectListGroup>()
            {
                { "6a3d526e-1fb6-4de7-bde5-e0754fc58aec", new SelectListGroup { Name = "Lekarz Rodzinny" } },
                { "4e8effeb-0a99-4038-9420-0c543a3a28ac", new SelectListGroup { Name = "Endokrynolog" } },
                { "e86959d5-6eed-45f7-b5cb-6b8f68a4d085", new SelectListGroup { Name = "Laryngolog" } },
                { "690e47d4-996b-43b7-a23b-d9693cf5962c", new SelectListGroup { Name = "Stomatolog" } },
            };

            AddVisitViewModel viewModel = new AddVisitViewModel()
            {
                Patients = (await patientRepository.GetAllAsync()).Select(x => new SelectListItem($"{x.Name} {x.Surname}", x.Id)),
                Doctors = (await doctorRepository.GetAllAsync()).Select(x => new SelectListItem { Text = $"{x.Name} {x.Surname}", Value = x.Id, Group = doctordic[x.SpecializationId.Trim()] }),
                Rooms = (await roomRepository.GetAllAsync()).Select(x => new SelectListItem($"{x.Number}", x.Id)),
            };
            return viewModel;

        }

        public async Task<UpdateNurseViewModel> GetUpdateNurseViewModel(string name)
        {
            Nurse nurse = await nurseRepository.GetByNameAsync(name);

            if (nurse == null)
            {
                throw new Exception("Nurse does not exist");
            }

            UpdateNurseViewModel viewModel = new UpdateNurseViewModel()
            {
                Id = nurse.Id,
                Surname = nurse.Surname,
                Name = nurse.Name,
                Address = nurse.Address,
                PermissionNumber = nurse.PermissionNumber
            };
            return viewModel;
        }

        public async Task<IdentityUser> GetUser(string name)
        {
            return await userRepository.GetByNameAsync(name);

        }

        public async Task UpdateNurseAsync(UpdateNurseViewModel model)
        {

            Nurse nurse = await nurseRepository.GetByIdAsync(model.Id);

            nurse.Surname = model.Surname;
            nurse.Address = model.Address;
            nurse.PermissionNumber = model.PermissionNumber;
            nurse.Name = model.Name;

            await nurseRepository.UpdateAsync(nurse);
        }

        public async Task<IEnumerable<ShowUsersViewModel>> ShowUsers()
        {
            IEnumerable<ShowUsersViewModel> nurse = (await nurseRepository.GetAllAsync()).Select(n => new ShowUsersViewModel { UserName = $"{n.Name} {n.Surname}", Role = "Nurse" });
            IEnumerable<ShowUsersViewModel> patient = (await patientRepository.GetAllAsync()).Select(n => new ShowUsersViewModel { UserName = $"{n.Name} {n.Surname}", Role = "Patient" });
            IEnumerable<ShowUsersViewModel> doctor = (await doctorRepository.GetAllAsync()).Select(n => new ShowUsersViewModel { UserName = $"{n.Name} {n.Surname}", Role = "Doctor" });
            IEnumerable<ShowUsersViewModel> viewModelUser = nurse.Concat(patient).Concat(doctor);

            return viewModelUser;
        }

        public async Task<List<TimeSheetViewModel>> ShowTimesheet()
        {
            List<TimeSheetViewModel> viewModel = await timesheetRepository.GetAllAsync().Select(t => new TimeSheetViewModel { Patient = $"{t.Patient.Name} {t.Patient.Surname}", Doctor = $"{t.Doctor.Name} {t.Doctor.Surname}", Room = t.Room.Number, Date = t.Data, Id = t.Id }).ToListAsync();
            return viewModel;

        }

        public async Task<NurseViewModel> GetNurseAsync(string name)
        {
            Nurse nurse = await nurseRepository.GetByNameAsync(name);

            return new NurseViewModel { Address = nurse.Address, Name = nurse.Name, Id = nurse.Id, PermissionNumber = nurse.PermissionNumber, Surname = nurse.Surname };
        }
    }
}
