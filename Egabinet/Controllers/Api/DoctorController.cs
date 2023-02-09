using Core.Domain;
using Egabinet.Data;
using Egabinet.Models;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Egabinet.Controllers.Api

{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public DoctorController(ApplicationDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorViewModel>> GetDoctor(string id)
        {
            var doctor = await _dbContext.Doctor.FirstOrDefaultAsync(d => d.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }
            var doctorviemodel = new DoctorViewModel { Id = doctor.Id, Name = doctor.Name, Surname = doctor.Surname, Adress = doctor.Adress, PermissionNumber = doctor.PermissionNumber, SpecializationId = doctor.SpecializationId };

            return Ok(doctorviemodel);
        }


        [HttpDelete]
        public async Task<ActionResult<Doctor>> DeleteDoctor(string id)
        {
            Doctor doctor = await _dbContext.Doctor.FirstOrDefaultAsync(p => p.Id == id);
            if (doctor == null)
            {
                return NotFound();
            }
            _dbContext.Doctor.Remove(doctor);
            _dbContext.SaveChanges();
            return Ok(doctor);
        }

        [HttpPost]
        public ActionResult<Doctor> AddDoctor([FromBody] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Doctor.Add(doctor);
                _dbContext.SaveChanges();
                return Created($"/api/nurse/{doctor.Id}", doctor);
            }
            return BadRequest(ModelState);

        }
    }
}






