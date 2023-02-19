using Core.Repositories;
using Egabinet.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Egabinet.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IUserRepository userRepository;
        private readonly ITimesheetRepository timesheetRepository;
        private readonly IDoctorRepository doctorRepository;




        public DoctorService(IUserRepository userRepository, ITimesheetRepository timesheetRepository, IDoctorRepository doctorRepository)
        {
            this.userRepository = userRepository;
            this.timesheetRepository = timesheetRepository;
            this.doctorRepository = doctorRepository;
        }


        public async Task<UpdateDoctorViewModel> GetUpdateDoctorViewModel(string name)
        {
            var doctor = await doctorRepository.GetByNameAsync(name);

            if (doctor == null)
            {
                throw new Exception("Doctor does not exist");
            }

            UpdateDoctorViewModel viewModel = new UpdateDoctorViewModel()
            {
                Id = doctor.Id,
                Surname = doctor.Surname,
                Name = doctor.Name,
                Adress = doctor.Adress,
                PermissionNumber = doctor.PermissionNumber
            };
            return viewModel;
        }

        public async Task<IdentityUser> GetUser(string name)
        {
            return await userRepository.GetByNameAsync(name);
        }

        public async Task UpdateDoctorAsync(UpdateDoctorViewModel model)
        {

            var doctor = await doctorRepository.GetByIdAsync(model.Id);

            doctor.Surname = model.Surname;
            doctor.Adress = model.Adress;
            doctor.PermissionNumber = model.PermissionNumber;
            doctor.Name = model.Name;

            await doctorRepository.UpdateAsync(doctor);
        }

        public async Task<List<TimeSheetViewModel>> ShowTimesheet(string name)
        {
            var doctor = await GetUser(name);

            var viewModel = await timesheetRepository.GetAllByDoctorIdAsync(doctor.Id).Select(t => new TimeSheetViewModel { Patient = $"{t.Patient.Name} {t.Patient.Surname}", Doctor = $"{t.Doctor.Name} {t.Doctor.Surname}", Room = t.Room.Number, Date = t.Data, Id = t.Id }).ToListAsync();
            return viewModel;
        }


        public async Task<DoctorViewModel> GetDoctorAsync(string name)
        {
            var doctor = await doctorRepository.GetByNameAsync(name);

            return new DoctorViewModel { Name = doctor.Name, Id = doctor.Id, PermissionNumber = doctor.PermissionNumber, Surname = doctor.Surname, SpecializationId = doctor.SpecializationId, Adress = doctor.Adress };
        }
    }
}
