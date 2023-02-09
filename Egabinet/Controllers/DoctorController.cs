using Egabinet.Data;
using Egabinet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Egabinet.Controllers
{
    public class DoctorController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public DoctorController(ApplicationDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }
        [Authorize]
        public IActionResult Index()
        {
            Microsoft.AspNetCore.Identity.IdentityUser? user = _dbContext.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> ShowTimesheet()
        {
            var viewModel = await _dbContext.TimeSheet.Select(t => new TimeSheetViewModel { Patient = t.Patient.Name, Doctor = t.Doctor.Name, Room = t.Room.Number, Date = t.Data, Id = t.Id }).ToListAsync();
            return View(viewModel);
        }


        [HttpGet]
        public async Task<IActionResult> EditDoctor()

        {
            if (User.Identity == null)
            {
                return RedirectToAction("Index");
            }

            var doctor = await _dbContext.Doctor.FirstOrDefaultAsync(u => u.User.UserName == User.Identity.Name);

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

            return await Task.Run(() => View("EditDoctor", viewModel));
        }

        [HttpPost]
        public async Task<IActionResult> EditDoctor(UpdateDoctorViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var doctor = await _dbContext.Doctor.FindAsync(model.Id);
            doctor.Surname = model.Surname;
            doctor.Name = model.Name;
            doctor.Adress = model.Adress;
            doctor.PermissionNumber = model.PermissionNumber;

            await _dbContext.SaveChangesAsync();
            return RedirectToAction("Index");

        }

    }
}
