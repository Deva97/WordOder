using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using WorkOrder.Context;
using WorkOrder.Model;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace WorkOrder.Controller
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        private readonly WorkDbContext _dbContext;
        public WorkController(WorkDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("{date}")]
        public ActionResult<List<Work>> GetAllWorkOrderByDate(DateTime date)
        {
            var work = _dbContext.Works.Where(x => x.InterventionTime.Date.Equals(date.Date)).ToList();
            if (work is null)
            {
                return NoContent();
            }
            else
                return Ok(work);
        }
        [HttpGet("{id}")]
        public ActionResult<List<Work>> GetWorkOrderbyTechnicianId(Guid id)
        {
            var technician = _dbContext.Technicians.FirstOrDefault(x => x.TechnicianId == id.ToString());
            if (technician is not null)
            {
                var orderIdList = _dbContext.WorkBoards.Where(x => x.TechnicianId.Equals(id.ToString())).Select(x => x.WorkId).ToList();
                var work = _dbContext.Works.Where(x => orderIdList.Contains(x.WorkOrderId)).ToList();
                if (work is null)
                {
                    return NoContent();
                }
                else
                    return Ok(work);
            }
            else
                return NotFound("Technician id not found");
        }
        [HttpPost]
        public void Post()
        {

        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
           
        }

        [NonAction]
        public IQueryable Pagination<T>(IQueryable<T> QueryList, int PageNumber, int Pagesize)
        {
            if(PageNumber < 1)
            {
                PageNumber = 1;
            }
            if(Pagesize == 0)
            {
                Pagesize = 20;
            }
            return QueryList.Skip((PageNumber - 1) * Pagesize).Take(Pagesize);
        }
    }
}
