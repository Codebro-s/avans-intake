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
    [Route("api/performers")]
    [ApiController]
    public class PerformerController : ControllerBase
    {
        private readonly IService<Performer> _performers;

        public PerformerController(IService<Performer> performerService)
        {
            _performers = performerService;
        }

        // GET: api/performers
        [HttpGet]
        public IEnumerable<Performer> Get() => _performers.Get();

        // GET: api/performers/1
        [HttpGet("{id}", Name = "Get")]
        public Performer Get(int id) => _performers.Get(id);

        // POST: api/performers
        [HttpPost]
        public void Post([FromBody] Performer model) => _performers.Create(model);

        // PUT: api/performers/1
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Performer model) => _performers.Update(id, model);

        // DELETE: api/performers/1
        [HttpDelete("{id}")]
        public void Delete(int id) => _performers.Delete(id);
    }
}
