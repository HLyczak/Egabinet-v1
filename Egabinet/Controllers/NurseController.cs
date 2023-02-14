using Egabinet.Models;
using Egabinet.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Egabinet.Controllers
{
    public class NurseController : Controller
    {
        private readonly INurseService nurseService;

        public NurseController(INurseService nurseService)
        {
            this.nurseService = nurseService;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            var nurse = await nurseService.GetNurseAsync(User.Identity.Name);
            return View(nurse);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> EditNurse()
        {
            var viewModel = await nurseService.GetUpdateNurseViewModel(User.Identity.Name);
            return View("EditNurse", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> EditNurse(UpdateNurseViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await nurseService.UpdateNurseAsync(model);
            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> DeleteVisit(string id)
        {
            try
            {
                await nurseService.DeleteVisitAsync(id);
                return RedirectToAction("Index");
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"Visit with Id = {id} not found {e}");
                return NotFound();
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddVisit(AddVisitViewModel model)
        {
            await nurseService.AddVisit(model);
            return RedirectToAction("ShowTimesheet");
        }

        [HttpGet]
        public async Task<IActionResult> ShowTimesheet()
        {
            var viewModel = await nurseService.ShowTimesheet();
            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> ShowUsers()
        {
            var viewModelUser = await nurseService.ShowUsers();

            return View(viewModelUser);
        }


        [HttpGet]
        public async Task<IActionResult> AddVisit()
        {
            var viewModel = await nurseService.GetAddVisitViewModel();
            return View("AddVisit", viewModel);
        }

    }
}











