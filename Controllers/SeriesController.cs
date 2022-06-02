using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NetlixRecords.Context;
using NetlixRecords.Model;
using System.Collections;
using System.Linq;

namespace NetlixRecords.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class SeriesController : ControllerBase
    {
        private readonly SeriesDbContext _dbContext;

        public SeriesController(SeriesDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public Series Get(Guid id)
        {
            var series = _dbContext.Series.Find(id);
            return series;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Series series)
        {
            _dbContext.Series.Add(series);
            _dbContext.SaveChanges();

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
            var series = _dbContext.Series.Find(id);


            try
            {
                _dbContext.Series.Remove(series);
                _dbContext.SaveChanges();
                return StatusCode(StatusCodes.Status200OK);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet("[action]")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Client)]
        public IQueryable<Series> GetAllTheShows([FromQuery] string sort, [FromQuery] int pageNumber, int Pagesize)
        {
            IQueryable<Series> data = Enumerable.Empty<Series>().AsQueryable();
            switch (sort.ToLower()) 
            {

                case "asc" : data =  _dbContext.Series.Select(x => x).OrderBy(x => x.ReleaseDate);
                    break;
                case "desc": data =  _dbContext.Series.Select(x => x).OrderByDescending(x => x.ReleaseDate);
                    break;
                default: data = _dbContext.Series.Select(x => x);
                    break;
            }
            return Pagination(data, pageNumber, Pagesize);
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
    }
}
