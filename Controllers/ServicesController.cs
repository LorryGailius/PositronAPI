using Microsoft.AspNetCore.Mvc;
using PositronAPI.Models.Schedule;
using PositronAPI.Services.EmployeeService;
using PositronAPI.Services.ServicesService;
using System.ComponentModel.DataAnnotations;

namespace PositronAPI.Controllers
{
    public class ServicesController : ControllerBase
    {
        private readonly ServicesService _servicesService;
        private readonly EmployeeService _employeeService;


        public ServicesController(ServicesService servicesService, EmployeeService employeeService)
        {
            _servicesService = servicesService;
            _employeeService = employeeService;
        }

        [HttpPost]
        [Route("/service")]
        public async Task<ActionResult<Service>> CreateService([FromBody] Service body)
        {
            if (await IsValidService(body))
            {
                var response = await _servicesService.CreateService(body);

                if (response == null) { return BadRequest(); }
                else { return Ok(response); }
            }

            return BadRequest("Given object is not valid");
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

        public async Task<bool> IsValidService(Service service)
        {
            if (service == null ||
               String.IsNullOrEmpty(service.Name) ||
               service.Price == 0 ||
               service.Duration < TimeSpan.Zero ||
               service.Duration == TimeSpan.Zero ||
               service.Duration > TimeSpan.FromHours(24) ||
               await _employeeService.GetEmployee(service.EmployeeId) == null) { return false; }

            return true;
        }
    }
}
