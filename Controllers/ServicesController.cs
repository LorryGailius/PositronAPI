using Microsoft.AspNetCore.Mvc;
using PositronAPI.Models.Schedule;
using PositronAPI.Services.ServicesService;
using System.ComponentModel.DataAnnotations;

namespace PositronAPI.Controllers
{
    public class ServicesController : ControllerBase
    {
        private readonly ServicesService _servicesService;

        public ServicesController(ServicesService servicesService)
        {
            _servicesService = servicesService;
        }

        [HttpPost]
        [Route("/service")]
        public async Task<ActionResult<Service>> CreateService([FromBody] Service body)
        {
            if (body == null) { return BadRequest(); }
            var response = await _servicesService.CreateService(body);

            if (response == null) { return BadRequest(); }
            else { return Ok(response); }
        }

        [HttpDelete]
        [Route("/service/{serviceId}")]
        public async Task<ActionResult> DeleteService([FromRoute][Required] long serviceId)
        {
            var response = await _servicesService.DeleteService(serviceId);

            if (response == null) { return NotFound(); }
            return NoContent();
        }

        [HttpPut]
        [Route("/service/{serviceId}")]
        public async Task<ActionResult<Service>> EditService([FromBody] Service body, [FromRoute][Required] long serviceId)
        {
            if (body == null) { return BadRequest(); }
            var response = await _servicesService.EditService(body, serviceId);

            if (response == null) { return BadRequest(); }
            else { return Ok(response); }
        }

        [HttpGet]
        [Route("/service/{serviceId}")]
        public async Task<ActionResult<Service>> GetService([FromRoute][Required] long serviceId)
        {
            var response = await _servicesService.GetService(serviceId);

            if (response == null) { return NotFound(); }
            else { return Ok(response); }
        }

        // Get service by type
        [HttpGet]
        [Route("/service")]
        public async Task<ActionResult<Service>> GetServiceByType([FromQuery][Required] ServiceCategory category, [FromQuery] int top, [FromQuery] int skip)
        {
            if (top < 0 || skip < 0) { return BadRequest(); }

            var response = (top > 0 || skip > 0) ? await _servicesService.GetServices(category, top, skip) : await _servicesService.GetServices(category);

            if (response == null) { return NotFound(); }
            else { return Ok(response); }
        }
    }
}
