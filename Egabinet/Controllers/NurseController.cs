using Egabinet.Data;
using Egabinet.Models;
using Egabinet.Models.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Egabinet.Controllers
{
    public class NurseController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public NurseController(ApplicationDbContext _dbContext)
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
        public async Task<IActionResult> EditNurse()

        {
            if (User.Identity == null)
            {
                return RedirectToAction("Index");
            }

            var nurse = await _dbContext.Nurse.FirstOrDefaultAsync(u => u.User.UserName == User.Identity.Name);

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

        [HttpPut]
        public async Task<IActionResult> EditNurse(UpdateNurseViewModel model)
        {


            var nurse = await _dbContext.Nurse.FindAsync(model.Id);


            nurse.Surname = model.Surname;
            nurse.Address = model.Address;
            nurse.PermissionNumber = model.PermissionNumber;


            await _dbContext.SaveChangesAsync();

            return RedirectToAction("Index");

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


        [HttpPost]
        public async Task<IActionResult> AddVisit(AddVisitViewModel model)
        {
            var timesheet = new TimeSheet()
            {
                DoctorId = model.SelectedDoctor,
                PatientId = model.SelectedPatient,
                Data = model.SelectedData,
                RoomId = model.SelectedRoom,
            };
            await _dbContext.TimeSheet.AddAsync(timesheet);

            await _dbContext.SaveChangesAsync();
            return RedirectToAction("ShowTimesheet");


        }
        [HttpGet]
        public async Task<IActionResult> ShowTimesheet()
        {
            var viewModel = await _dbContext.TimeSheet.Select(t => new TimeSheetViewModel { Patient = t.Patient.Name, Doctor = t.Doctor.Name, Room = t.Room.Number, Date = t.Data, Id = t.Id }).ToListAsync();


            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> ShowUsers()
        {
            /*     var time = await _dbContext.TimeSheet.FirstOrDefaultAsync();*/

            /*Employees.FirstOrDefaultAsync(x => x.Id == id);*/

            return View();

        }


        [HttpGet]
        public async Task<IActionResult> AddVisit()
        {
            var doctordic = new Dictionary<string, SelectListGroup>()
            {
                { "6a3d526e-1fb6-4de7-bde5-e0754fc58aec", new SelectListGroup { Name = "Lekarz Rodzinny" } },
                { "4e8effeb-0a99-4038-9420-0c543a3a28ac", new SelectListGroup { Name = "Endokrynolog" } },
                { "e86959d5-6eed-45f7-b5cb-6b8f68a4d085", new SelectListGroup { Name = "Laryngolog" } },
                { "690e47d4-996b-43b7-a23b-d9693cf5962c", new SelectListGroup { Name = "Stomatolog" } },
            };

            AddVisitViewModel viewModel = new AddVisitViewModel()
            {
                Patients = await _dbContext.Patient.Select(x => new SelectListItem($"{x.Name} {x.Surname}", x.Id)).ToListAsync(),
                Doctors = await _dbContext.Doctor.Select(x => new SelectListItem { Text = $"{x.Name} {x.Surname}", Value = x.Id, Group = doctordic[x.SpecializationId.Trim()] }).ToListAsync(),
                Rooms = await _dbContext.Room.Select(x => new SelectListItem($"{x.Number}", x.Id)).ToListAsync(),


            };


            return await Task.Run(() => View("AddVisit", viewModel));
        }

    }
}











