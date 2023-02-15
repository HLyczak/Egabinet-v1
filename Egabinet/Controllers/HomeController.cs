using Egabinet.Models;
using Egabinet.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Egabinet.Controllers
{
    public class HomeController : Controller
    {

        private readonly IUserService userService;

        public HomeController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> Index()
        {
            var role = await userService.GetUserRole(User?.Identity?.Name);

            if (role == "nurse")
            {
                return RedirectToAction("Index", "Nurse");
            }
            return role == "patient" ? RedirectToAction("Index", "Patient") : role == "doctor" ? RedirectToAction("Index", "Doctor") : View();
        }



        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}