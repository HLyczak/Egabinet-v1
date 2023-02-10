using Core.Domain;
using Core.Repositories;
using Egabinet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Egabinet.Controllers
{
    public class NurseController : Controller
    {
        private readonly INurseRepository nurseRepository;
        private readonly IPatientRepository patientRepository;
        private readonly IUserRepository userRepository;
        private readonly IDoctorRepository doctorRepository;
        private readonly ITimesheetRepository timesheetRepository;
        private readonly IRoomRepository roomRepository;


        public NurseController(INurseRepository nurseRepository, IPatientRepository patientRepository, IUserRepository userRepository, IDoctorRepository doctorRepository, ITimesheetRepository timesheetRepository, IRoomRepository roomRepository)
        {
            this.nurseRepository = nurseRepository;
            this.patientRepository = patientRepository;
            this.userRepository = userRepository;
            this.doctorRepository = doctorRepository;
            this.timesheetRepository = timesheetRepository;
            this.roomRepository = roomRepository;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {

            var user = await userRepository.GetByNameAsync(User.Identity.Name);
            return View(user);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> EditNurse()

        {
            var nurse = await nurseRepository.GetByNameAsync(User.Identity.Name);

            if (nurse == null)
            {
                return RedirectToAction("Index");
            }

            UpdateNurseViewModel viewModel = new UpdateNurseViewModel()
            {
                Id = nurse.Id,
                Surname = nurse.Surname,
                Name = nurse.Name,
                Address = nurse.Address,
                PermissionNumber = nurse.PermissionNumber
            };

            return View("EditNurse", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditNurse(UpdateNurseViewModel model)
        {
            var nurse = await nurseRepository.GetByIdAsync(model.Id);

            if (!ModelState.IsValid)
            {
                return View(model);
            }


            nurse.Surname = model.Surname;
            nurse.Address = model.Address;
            nurse.PermissionNumber = model.PermissionNumber;
            nurse.Name = model.Name;

            await nurseRepository.UpdateAsync(nurse);
            return RedirectToAction("Index");


        }
        [HttpPost]

        public async Task<IActionResult> DeleteVisit(string id)
        {

            var visitToDelete = await timesheetRepository.GetByIdAsync(id);
            if (visitToDelete != null)
            {
                await timesheetRepository.RemoveAsync(id);
            }

            return visitToDelete == null ? NotFound($"Visit with Id = {id} not found") : RedirectToAction("Index");
        }


        [HttpPost]
        public async Task<IActionResult> AddVisit(AddVisitViewModel model)
        {
            var timesheet = new TimeSheet()
            {
                DoctorId = model.SelectedDoctor,
                PatientId = model.SelectedPatient,
                Data = model.SelectedData,
                RoomId = model.SelectedRoom,
            };

            await timesheetRepository.AddAsync(timesheet);

            return RedirectToAction("ShowTimesheet");


        }
        [HttpGet]
        public async Task<IActionResult> ShowTimesheet()
        {

            var viewModel = await timesheetRepository.GetAllAsync().Select(t => new TimeSheetViewModel { Patient = t.Patient.Name, Doctor = t.Doctor.Name, Room = t.Room.Number, Date = t.Data, Id = t.Id }).ToListAsync();

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> ShowUsers()
        {
            var nurse = (await nurseRepository.GetAllAsync()).Select(n => new ShowUsersViewModel { UserName = $"{n.Name} {n.Surname} ", Role = "Nurse" });
            var patient = (await patientRepository.GetAllAsync()).Select(n => new ShowUsersViewModel { UserName = $"{n.Name} {n.Surname} ", Role = "Patient" });
            var doctor = (await doctorRepository.GetAllAsync()).Select(n => new ShowUsersViewModel { UserName = $"{n.Name} {n.Surname} ", Role = "Doctor" });
            var viewModelUser = nurse.Concat(patient).Concat(doctor);


            return View(viewModelUser);
        }


        [HttpGet]
        public async Task<IActionResult> AddVisit()
        {
            var doctordic = new Dictionary<string, SelectListGroup>()
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


            return await Task.Run(() => View("AddVisit", viewModel));
        }

    }
}











