using Microsoft.AspNetCore.Mvc;
using PositronAPI.Models.Employee;
using PositronAPI.Models.Order;
using PositronAPI.Models.Schedule;
using PositronAPI.Services.EmployeeService;
using PositronAPI.Services.ServicesService;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace PositronAPI.Controllers
{
    public class ServicesController : ControllerBase
    {
        private readonly IServicesService _servicesService;
        private readonly IEmployeeService _employeeService;


        public ServicesController(IServicesService servicesService, IEmployeeService employeeService)
        {
            _servicesService = servicesService;
            _employeeService = employeeService;
        }

        [HttpPost]
        [Route("/service")]
        public async Task<ActionResult<Service>> CreateService([FromBody] ServiceImportDTO body)
        {
            
            if (await IsValidService(body))
            {
                var response = await _servicesService.CreateService(body);

                if (response == null) { return BadRequest(); }
                else { return Created(String.Empty, response); }
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
        public async Task<ActionResult<Service>> EditService([FromBody][Required] ServiceUpdateDTO body, [FromRoute][Required] long serviceId)
        {
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

        public async Task<bool> IsValidService(ServiceImportDTO service)
        {
            var json = JsonConvert.SerializeObject(service);

            Console.WriteLine(json);

            Console.WriteLine(service.Duration);

            if (service == null ||
               String.IsNullOrEmpty(service.Name) ||
               service.Price == 0 ||
               await _employeeService.GetEmployee(service.EmployeeId) == null ||
                !Enum.IsDefined(typeof(ServiceCategory), service.Category))
            { return false; }

            return true;
        }
    }
}
