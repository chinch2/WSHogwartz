using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WSHogwartz.Business.Interfaces;
using WSHogwartz.Domain.Models;
using WSHogwartz.Dtos;

namespace WSHogwartz.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationsController : ControllerBase
    {
        private readonly IApplicationBusiness _applicationBusiness;
        private readonly IMapper _mapper;

        public ApplicationsController(IApplicationBusiness applicationBusiness, IMapper mapper)
        {
            _applicationBusiness = applicationBusiness;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IEnumerable<ApplicationDto>> GetApplications()
        {
            var applicationsDom = await _applicationBusiness.GetAllApplicationsAsync();

            var applicationsDto = _mapper.Map<IEnumerable<ApplicationDto>>(applicationsDom);

            return applicationsDto;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationDto>> GetApplications(int id)
        {
            var applicationDom = await _applicationBusiness.GetSingleApplicationAsync(id);

            if (applicationDom == null)
                return NotFound();

            var applicationDto = _mapper.Map<ApplicationDto>(applicationDom);

            return applicationDto;
        }

        [HttpPost]
        public async Task<ActionResult<ApplicationDto>> PostApplications([FromBody] CreateApplicationDto createApplicationDto)
        {
            try
            {
                var applicationDom = _mapper.Map<ApplicationDomain>(createApplicationDto);
                var newApplicationDom = await _applicationBusiness.CreateApplicationAsync(applicationDom);
                var newApplicationDto = _mapper.Map<ApplicationDto>(newApplicationDom);

                return CreatedAtAction(nameof(GetApplications), new { id = newApplicationDto.Id }, newApplicationDto);
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult> PutApplications(int id, [FromBody] UpdateApplicationDto updateApplicationDto)
        {
            try
            {
                var applicationDom = _mapper.Map<ApplicationDomain>(updateApplicationDto);

                if (id != applicationDom.Id)
                    return BadRequest();

                /*var applicationToUpdateDom = await _applicationBusiness.GetSingleApplicationAsync(applicationDom.Id);

                if (applicationToUpdateDom == null)
                    return NotFound();
                */

                await _applicationBusiness.UpdateApplicationAsync(applicationDom);

                return NoContent();
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteApplications(int id)
        {
            try
            {
                var applicationToDeleteDom = await _applicationBusiness.GetSingleApplicationAsync(id);

                if (applicationToDeleteDom == null)
                    return NotFound();

                await _applicationBusiness.DeleteApplicationAsync(id);

                return NoContent();
            }
            catch (Exception ex)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
