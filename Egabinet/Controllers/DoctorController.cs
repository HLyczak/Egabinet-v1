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

    }
}
