using Core.Domain;
using Egabinet.Data;
using Egabinet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Egabinet.Controllers.Api
{

    [Route("api/[controller]")]
    [ApiController]
    public class NurseController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public NurseController(ApplicationDbContext _dbContext)
        {
            this._dbContext = _dbContext;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<NurseViewModel>> GetNurse(string id)
        {
            var nurse = await _dbContext.Nurse.FirstOrDefaultAsync(d => d.Id == id);
            if (nurse == null)
            {
                return NotFound();
            }
            var nurseviewmodel = new NurseViewModel { Id = nurse.Id, Name = nurse.Name, Surname = nurse.Surname, PermissionNumber = nurse.PermissionNumber };

            return Ok(nurseviewmodel);
        }


        [HttpPost]
        public ActionResult<Nurse> AddNurse([FromBody] Nurse nurse)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Nurse.Add(nurse);
                _dbContext.SaveChanges();
                return Created($"/api/nurse/{nurse.Id}", nurse);
            }
            return BadRequest(ModelState);

        }
        [HttpDelete]
        public async Task<ActionResult<Nurse>> DeleteNurse(string id)
        {
            Nurse nurse = await _dbContext.Nurse.FirstOrDefaultAsync(d => d.Id == id);
            if (nurse == null)
            {
                return NotFound();
            }
            _dbContext.Nurse.Remove(nurse);
            _dbContext.SaveChanges();
            return Ok(nurse);
        }
    }

}
