using Egabinet.Models;
using Egabinet.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Egabinet.Controllers
{
    public class DoctorController : Controller
    {
        private readonly IDoctorService doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            this.doctorService = doctorService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var doctor = await doctorService.GetDoctorAsync(User.Identity.Name);
            return View(doctor);
        }

        [HttpGet]
        public async Task<IActionResult> ShowTimesheet()
        {
            var viewModel = await doctorService.ShowTimesheet(User.Identity.Name);
            return View(viewModel);
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> EditDoctor()
        {
            var viewModel = await doctorService.GetUpdateDoctorViewModel(User.Identity.Name);
            return View("EditDoctor", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditDoctor(UpdateDoctorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await doctorService.UpdateDoctorAsync(model);

            return RedirectToAction("Index");
        }
    }
}
