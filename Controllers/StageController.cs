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
    [Route("api/stages")]
    [ApiController]
    public class StageController : ControllerBase
    {
        private readonly IService<Stage> _stages;

        public StageController(IService<Stage> stageService)
        {
            _stages = stageService;
        }

        // GET: api/stages
        [HttpGet]
        public IEnumerable<Stage> Get() => _stages.Get();

        // GET: api/stages/1
        [HttpGet("{id}", Name = "Get")]
        public Stage Get(int id) => _stages.Get(id);

        // POST: api/stages
        [HttpPost]
        public void Post([FromBody] Stage model) => _stages.Create(model);

        // PUT: api/stages/1
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Stage model) => _stages.Update(id, model);

        // DELETE: api/stages/1
        [HttpDelete("{id}")]
        public void Delete(int id) => _stages.Delete(id);
    }
}
