using Egabinet.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

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
    }
}
