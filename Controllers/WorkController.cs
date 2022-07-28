using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using WorkOrder.Context;
using WorkOrder.Model;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;

namespace WorkOrder.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkController : ControllerBase
    {
        private readonly WorkDbContext _dbContext;
        public WorkController(WorkDbContext dbContext)
        {
            _dbContext = dbContext;;
        }
        // GET api/<ValuesController>/5
        //[HttpGet("{id}")]
        //public Series Get(Guid id)
        //{
        //    var series = _dbContext.Series.Find(id);
        //    return series;
        //}

        // POST api/<ValuesController>
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
        public IActionResult Delete(int id)
        {
           
        }

        [HttpGet("[action]")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client)]
        public IQueryable<Series> GetAllTheShows([FromQuery] string sort, [FromQuery] int pageNumber, int Pagesize)
        {
         
        }

        [NonAction]
        public IQueryable<Series> Pagination(IQueryable<Series> series,int PageNumber, int Pagesize)
        {
            if(PageNumber < 1)
            {
                PageNumber = 1;
            }
            if(Pagesize == 0)
            {
                Pagesize = 20;
            }
            return series.Skip((PageNumber - 1) * Pagesize).Take(Pagesize);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
        }
    }
}
