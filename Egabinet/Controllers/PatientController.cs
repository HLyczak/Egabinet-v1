using Egabinet.Data;
using Egabinet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Egabinet.Controllers
{
    public class PatientController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public PatientController(ApplicationDbContext _dbContext)
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
            var user = _dbContext.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            var viewModel = await _dbContext.TimeSheet.Where(t => t.Patient.UserId == user.Id).Select(t => new TimeSheetViewModel { Patient = t.Patient.Name, Doctor = t.Doctor.Name, Room = t.Room.Number, Date = t.Data, Id = t.Id }).ToListAsync();

            return View(viewModel);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteVisit(string id)
        {
            try
            {
                var visitToDelete = await _dbContext.TimeSheet.FindAsync(id);
                if (visitToDelete != null)
                {
                    _dbContext.TimeSheet.Remove(visitToDelete);
                    await _dbContext.SaveChangesAsync();
                }

                return visitToDelete == null ? NotFound($"Visit with Id = {id} not found") : RedirectToAction("Index");

            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }

        }
        //edit
        [HttpGet]
        public async Task<IActionResult> EditPatient()

        {
            if (User.Identity == null)
            {
                return RedirectToAction("Index");
            }

            var patient = await _dbContext.Patient.FirstOrDefaultAsync(u => u.User.UserName == User.Identity.Name);

            if (patient == null)
            {
                return RedirectToAction("Index");
            }

            UpdatePatientViewModel viewModel = new UpdatePatientViewModel()
            {
                Id = patient.Id,
                Address = patient.Address,
            };

            return await Task.Run(() => View("EditPatient", viewModel));
        }

        [HttpPut]
        public async Task<IActionResult> EditPatient(UpdatePatientViewModel model)
        {

            var patient = await _dbContext.Patient.FindAsync(model.Id);
            patient.Address = model.Address;


            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index");

        }
    }

}
