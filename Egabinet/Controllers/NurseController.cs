using Egabinet.Data;
using Egabinet.Models;
using Egabinet.Models.Domain;
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
            var user = dbContext.Users.FirstOrDefault(u => u.UserName == User.Identity.Name);
            return View(user);
        }

        [HttpGet]
        public async Task<IActionResult> EditNurse()
       
        {
            var employee = await dbContext.Users.FirstOrDefaultAsync(u => u.UserName == User.Identity.Name);

            if (employee != null)
            {

                var viewModel = new UpdateNurseViewModel()
                {
                    Id = employee.Id,
                    Surname = employee.Surname,
                    DateOfBirth = employee.DateOfBirth,
                    Role = employee.Role,


                };

                return await Task.Run(() => View("EditNurse", viewModel));
            }

            return RedirectToAction("Index");

        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateNurseViewModel model)
        {

            var employee = await dbContext.Users.FindAsync(model.Id);
            if (employee != null)
            {
        
                employee.Surname = model.Surname;
                employee.DateOfBirth = model.DateOfBirth;
                employee.Role = model.Role;


                await dbContext.SaveChangesAsync();

                return RedirectToAction("Index");

            }
            return RedirectToAction("Index");

        }

    }
}
