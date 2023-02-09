using Core.Domain;
using Egabinet.Data;
using Egabinet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Egabinet.Controllers.Api
{

    [Route("api/[controller]")]
    [ApiController]
    public class PatientController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public PatientController(ApplicationDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PatientViewModel>> GetPatient(string id)
        {
            var patient = await _dbContext.Patient.FirstOrDefaultAsync(d => d.Id == id);
            if (patient == null)
            {
                return NotFound();
            }
            var patientviewmodel = new PatientViewModel { Id = patient.Id, Name = patient.Name, Surname = patient.Surname, Address = patient.Address };
            ; return Ok(patientviewmodel);
        }


        [HttpPost]
        public ActionResult<Patient> AddPatient([FromBody] Patient patient)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Patient.Add(patient);
                _dbContext.SaveChanges();
                return Created($"/api/patient/{patient.Id}", patient);
            }
            return BadRequest(ModelState);

        }
        [HttpDelete]
        public async Task<ActionResult<Patient>> DeletePatient(string id)
        {
            Patient patient = await _dbContext.Patient.FirstOrDefaultAsync(d => d.Id == id);
            if (patient == null)
            {
                return NotFound();
            }
            _dbContext.Patient.Remove(patient);
            _dbContext.SaveChanges();
            return Ok(patient);
        }
    }

}

