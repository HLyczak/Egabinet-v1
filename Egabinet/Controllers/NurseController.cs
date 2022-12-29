using Egabinet.Data;
using Egabinet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Egabinet.Controllers
{
    public class NurseController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public NurseController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [Authorize]
        public IActionResult Index()
        {
            Microsoft.AspNetCore.Identity.IdentityUser? user = dbContext.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> EditNurse()

        {
            if (User.Identity == null)
            {
                return RedirectToAction("Index");
            }

            var nurse = await dbContext.Nurse.FirstOrDefaultAsync(u => u.User.UserName == User.Identity.Name);

            if (nurse == null)
            {
                return RedirectToAction("Index");
            }

            UpdateNurseViewModel viewModel = new UpdateNurseViewModel()
            {
                Id = nurse.Id,
                Surname = nurse.Surname,
                Address = nurse.Address,
                PermissionNumber = nurse.PermissionNumber
            };

            return await Task.Run(() => View("EditNurse", viewModel));
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateNurseViewModel model)
        {

            var IdentityUser = await dbContext.Users.FindAsync(User.Identity.Name);
            var nurse = await dbContext.Nurse.FindAsync(model.Id);


            nurse.Surname = model.Surname;
            nurse.Address = model.Address;
            nurse.PermissionNumber = model.PermissionNumber;


            await dbContext.SaveChangesAsync();

            return RedirectToAction("Index");



        }

        [HttpPost]
        public async Task<IActionResult> AddVisit(AddVisitViewModel model)
        {
            /*            var visit = new Visit()
                        {
                            DoctorId = model.SelectedDoctor,
                            PatientId = model.SelectedPatient,
                            Data = model.SelectedData,
                        };
                        await dbContext.Visits.AddAsync(visit);

                        await dbContext.SaveChangesAsync();*/
            return RedirectToAction("Index");


        }

    }
}






