using Core.Repositories;
using Egabinet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Egabinet.Controllers
{
    public class DoctorController : Controller
    {

        private readonly IDoctorRepository doctorRepository;
        private readonly ITimesheetRepository timesheetRepository;
        private readonly IUserRepository userRepository;


        public DoctorController(IDoctorRepository doctorRepository, ITimesheetRepository timesheetRepository, IUserRepository userRepository)
        {

            this.doctorRepository = doctorRepository;
            this.timesheetRepository = timesheetRepository;
            this.userRepository = userRepository;

        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var user = await userRepository.GetByNameAsync(User.Identity.Name);
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> ShowTimesheet()
        {
            var user = await doctorRepository.GetByNameAsync(User.Identity.Name);
            var viewModel = await timesheetRepository.GetAllByPatientIdAsync(user.Id).Select(t => new TimeSheetViewModel { Patient = t.Patient.Name, Doctor = t.Doctor.Name, Room = t.Room.Number, Date = t.Data, Id = t.Id }).ToListAsync();
            return View(viewModel);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> EditDoctor()
        {

            var doctor = await doctorRepository.GetByNameAsync(User.Identity.Name);

            if (doctor == null)
            {
                return RedirectToAction("Index");
            }

            UpdateDoctorViewModel viewModel = new UpdateDoctorViewModel()
            {
                Id = doctor.Id,
                Surname = doctor.Surname,
                Adress = doctor.Adress,
                Name = doctor.Name,
                PermissionNumber = doctor.PermissionNumber
            };

            return View("EditDoctor", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditDoctor(UpdateDoctorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var doctor = await doctorRepository.GetByIdAsync(model.Id);
            doctor.Surname = model.Surname;
            doctor.Name = model.Name;
            doctor.Adress = model.Adress;
            doctor.PermissionNumber = model.PermissionNumber;

            await doctorRepository.UpdateAsync(doctor);
            return RedirectToAction("Index");

        }

    }
}
