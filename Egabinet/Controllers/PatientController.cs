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
            var viewModel = await _dbContext.TimeSheet.Select(t => new TimeSheetViewModel { Patient = t.Patient.Name, Doctor = t.Doctor.Name, Room = t.Room.Number, Date = t.Data, Id = t.Id }).ToListAsync();


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
    }

}
