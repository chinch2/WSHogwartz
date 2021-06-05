using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSHogwartz.Models;
using WSHogwartz.Repositories;

namespace WSHogwartz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly IApplicationRepository _applicationRepository;

        public ApplicationsController(IApplicationRepository applicationRepository)
        {
            _applicationRepository = applicationRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Application>> GetApplications()
        {
            return await _applicationRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Application>> GetApplications(int id)
        {
            return await _applicationRepository.Get(id);
        }

        [HttpPost]
        public async Task<ActionResult<Application>> PostApplications([FromBody] Application application)
        {
            var newApplication = await _applicationRepository.Create(application);
            return CreatedAtAction(nameof(GetApplications), new { id = newApplication.Id }, newApplication);
        }

        [HttpPut]
        public async Task<ActionResult> PutApplications(int id, [FromBody] Application application)
        {
            if(id != application.Id)
            {
                return BadRequest();
            }

            await _applicationRepository.Update(application);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteApplications(int id)
        {
            var applicationToDelete = await _applicationRepository.Get(id);
            if (applicationToDelete == null)
                return NotFound();

            await _applicationRepository.Delete(applicationToDelete.Id);
            return NoContent();
        }
    }
}
