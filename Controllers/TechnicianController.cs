using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorkOrder.Context;
using WorkOrder.Model;

namespace WorkOrder.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TechnicianController : ControllerBase
    {
        private readonly WorkDbContext _dbContext;
        public TechnicianController(WorkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpPost]
        public ActionResult<string> CreateTechnician([FromBody] AddTechnicianCommand request)
        {
            try
            {
                var tech = new AddTechnicianCommand() { FirstName = "Deva", LastName = "Raut", IsActive = true };
                _dbContext.Add(tech);
                _dbContext.SaveChanges();
                return Ok($"New Technician created with ID {tech.TechnicianId}");
            }
            catch(Exception e)
            {
                return StatusCode(500, $"exception occured {e}");
            }
        }

        [HttpPut]
        public ActionResult<string> DisableTechnician([FromQuery]Guid id)
        {
            var tech = _dbContext.Technicians.FirstOrDefault(x => x.TechnicianId.Equals(id.ToString()));
            if(tech is null)
            {
                return StatusCode(400, "Technician id didnt exist");
            }
            try
            {
                _dbContext.SaveChanges();
                return StatusCode(200, "Technician is disabled");
            }
            catch(Exception e)
            {
                return StatusCode(500, $"Exception occured {e}");
            }
        }

        [HttpPost]
        public ActionResult<string> AssignTechnicianToWork([FromBody] AssignTechnician request)
        {
            var tech = _dbContext.Technicians.FirstOrDefault(x => x.TechnicianId.Equals(request.TechnicianId));
            if(tech is null)
            {
                return StatusCode(404, "Technician not exist");
            }
            var work = _dbContext.Works.FirstOrDefault(x => x.WorkOrderId.Equals(request.WorkId));
            if(work is null)
            {
                return StatusCode(404, "workOrder doesnt exist");
            }
            var assigntech = new WorkBoard() { TechnicianId = request.TechnicianId, JobId = request.WorkId, IsWorkDone = false, IsWorkOrderActive = true };
            try
            {
                _dbContext.Add(assigntech);
                _dbContext.SaveChanges();
                return Ok("Technician is assigned");
            }
            catch(Exception e)
            {
                return StatusCode(500, $"exception occured {e}");
            }
        }
    }
}
