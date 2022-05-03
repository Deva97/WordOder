using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using NetlixRecords.Context;
using NetlixRecords.Model;

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
    }
}
