using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BandScheduler.Models;
using BandScheduler.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BandScheduler.Controllers
{
    [Route("api/performances")]
    [ApiController]
    public class PerformanceController : ControllerBase
    {
        private readonly IPerformanceService _performances;

        public PerformanceController(IPerformanceService performanceService)
        {
            _performances = performanceService;
        }

        // GET: api/performances/stage/1
        [HttpGet("stage/{id}")]
        public IEnumerable<Performance> GetByStage(int id) => _performances.GetByStage(id);

        // GET: api/performances
        [HttpGet]
        public IEnumerable<Performance> Get() => _performances.Get();

        // GET: api/performances/1
        [HttpGet("{id}")]
        public Performance Get(int id) => _performances.Get(id);

        // POST: api/performances
        [HttpPost]
        public void Post([FromBody] Performance model, [FromQuery] string startDateString, [FromQuery] string endDateString) => _performances.Create(model, startDateString, endDateString);

        // PUT: api/performances/1
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Performance model) => _performances.Update(id, model);

        // DELETE: api/performances/1
        [HttpDelete("{id}")]
        public void Delete(int id) => _performances.Delete(id);
    }
}
