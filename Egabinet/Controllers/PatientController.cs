using Core.Repositories;
using Egabinet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Egabinet.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientRepository patientRepository;
        private readonly IUserRepository userRepository;
        private readonly ITimesheetRepository timesheetRepository;


        public PatientController(IPatientRepository patientRepository, IUserRepository userRepository, ITimesheetRepository timesheetRepository)
        {
            this.patientRepository = patientRepository;
            this.userRepository = userRepository;
            this.timesheetRepository = timesheetRepository;
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

            var user = await patientRepository.GetByNameAsync(User.Identity.Name);
            var viewModel = await timesheetRepository.GetAllByPatientIdAsync(user.Id).Select(t => new TimeSheetViewModel { Patient = t.Patient.Name, Doctor = t.Doctor.Name, Room = t.Room.Number, Date = t.Data, Id = t.Id }).ToListAsync();

            return View(viewModel);
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
        //edit
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> EditPatient()

        {

            var patient = await patientRepository.GetByNameAsync(User.Identity.Name);

            if (patient == null)
            {
                return RedirectToAction("Index");
            }

            UpdatePatientViewModel viewModel = new UpdatePatientViewModel()
            {
                Id = patient.Id,
                Address = patient.Address,
            };

            return View("EditPatient", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditPatient(UpdatePatientViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var patient = await patientRepository.GetByIdAsync(model.Id);
            patient.Address = model.Address;


            await patientRepository.UpdateAsync(patient);

            return RedirectToAction("Index");

        }
    }

}
