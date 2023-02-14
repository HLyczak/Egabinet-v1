using Egabinet.Models;
using Egabinet.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Egabinet.Controllers
{
    public class PatientController : Controller
    {
        private readonly IPatientService patientService;


        public PatientController(IPatientService patientService)
        {
            this.patientService = patientService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var patient = await patientService.GetPatientAsync(User.Identity.Name);
            return View(patient);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> ShowTimesheet()
        {

            var viewModel = await patientService.ShowTimesheet(User.Identity.Name);
            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> DeleteVisit(string id)
        {
            try
            {
                await patientService.DeleteVisitAsync(id);
                return RedirectToAction("Index");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Visit with Id = {id} not found {e}");
                return NotFound();
            }
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> EditPatient()
        {
            var viewModel = await patientService.GetUpdatePatientViewModel(User.Identity.Name);
            return View("EditPatient", viewModel);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> EditPatient(UpdatePatientViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await patientService.UpdatePatientAsync(model);

            return RedirectToAction("Index");
        }
    }

}
