using Microsoft.AspNetCore.Mvc;
using PositronAPI.Models.Employee;
using PositronAPI.Services.EmployeeService;
using System.ComponentModel.DataAnnotations;

namespace PositronAPI.Controllers
{
    public class EmployeesController : ControllerBase
    {
        private readonly EmployeeService _employeeService;

        public EmployeesController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpPost]
        [Route("/employee")]
        public async Task<ActionResult<Employee>> CreateEmployee([FromBody] Employee body)
        {
            if (body == null) { return BadRequest(); }
            var response = await _employeeService.CreateEmployee(body);

            if (response == null) { return BadRequest(); }
            else { return Ok(response); }
        }

        [HttpDelete]
        [Route("/employee/{employeeId}")]
        public async Task<ActionResult> DeleteEmployee([FromRoute][Required] long employeeId)
        {
            var response = await _employeeService.DeleteEmployee(employeeId);

            if (response == null) { return NotFound(); }
            return NoContent();
        }

        [HttpPut]
        [Route("/employee/{employeeId}")]
        public async Task<ActionResult<Employee>> EditEmployee([FromBody] Employee body, [FromRoute][Required] long employeeId)
        {
            if (body == null) { return BadRequest(); }
            var response = await _employeeService.EditEmployee(body, employeeId);

            if (response == null) { return BadRequest(); }
            else { return Ok(response); }
        }

        [HttpGet]
        [Route("/employee/{employeeId}")]
        public async Task<ActionResult<Employee>> GetEmployee([FromRoute][Required] long employeeId)
        {
            var response = await _employeeService.GetEmployee(employeeId);

            if (response == null) { return NotFound(); }
            else { return Ok(response); }
        }

        // /employee /employee by role /employee by department
        [HttpGet]
        [Route("/employee")]
        public async Task<ActionResult<List<Employee>>> GetEmployees([FromQuery] int top, [FromQuery] int skip)
        {
            if (top < 0 || skip < 0) { return BadRequest(); }

            var response = (top > 0 || skip > 0) ? await _employeeService.GetEmployees(top, skip) : await _employeeService.GetEmployees();

            if (response == null) { return NotFound(); }
            else { return Ok(response); }
        }

        [HttpGet]
        [Route("/employee/role/{roleId}")]
        public async Task<ActionResult<List<Employee>>> GetEmployeesByRole([FromRoute][Required] long roleId, [FromQuery] int top, [FromQuery] int skip)
        {
            if(top < 0 || skip < 0) { return BadRequest(); }

            var response = (top > 0 || skip > 0) ? await _employeeService.GetEmployees(roleId, top, skip) : await _employeeService.GetEmployees(roleId);

            if (response == null) { return NotFound(); }
            else { return Ok(response); }
        }

        [HttpGet]
        [Route("/employee/department/{departmentId}")]
        public async Task<ActionResult<List<Employee>>> GetEmployeesByDepartment([FromRoute][Required] long departmentId, [FromQuery] int top, [FromQuery] int skip)
        {
            if(top < 0 || skip < 0) { return BadRequest(); }

            var response = (top > 0 || skip > 0) ? await _employeeService.GetEmployees(departmentId, top, skip) : await _employeeService.GetEmployees(departmentId);

            if (response == null) { return NotFound(); }
            else { return Ok(response); }
        }
    }
}
