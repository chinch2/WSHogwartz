using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSHogwartz.Dtos;
using WSHogwartz.Models;
using WSHogwartz.Repositories;

namespace WSHogwartz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly IApplicationRepository _applicationRepository;
        private readonly IMapper _mapper;

        public ApplicationsController(IApplicationRepository applicationRepository, IMapper mapper)
        {
            _applicationRepository = applicationRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ApplicationDto>> GetApplications()
        {
            var applications = await _applicationRepository.Get();
            var applicationsDto = _mapper.Map<IEnumerable<ApplicationDto>>(applications);

            return applicationsDto;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationDto>> GetApplications(int id)
        {
            var application = await _applicationRepository.Get(id);

            if (application == null)
                return NotFound();

            var applicationDto = _mapper.Map<ApplicationDto>(application);

            return applicationDto;
        }

        [HttpPost]
        public async Task<ActionResult<ApplicationDto>> PostApplications([FromBody] CreateApplicationDto createApplicationDto)
        {
            var application = _mapper.Map<Application>(createApplicationDto);
            var newApplication = await _applicationRepository.Create(application);
            var newApplicationDto = _mapper.Map<ApplicationDto>(newApplication);

            return CreatedAtAction(nameof(GetApplications), new { id = newApplicationDto.Id }, newApplicationDto);
        }

        [HttpPut]
        public async Task<ActionResult> PutApplications(int id, [FromBody] UpdateApplicationDto updateApplicationDto)
        {
            var application = _mapper.Map<Application>(updateApplicationDto);

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
