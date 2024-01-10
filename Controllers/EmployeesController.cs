using Microsoft.AspNetCore.Mvc;
using PositronAPI.Models.Employee;
using PositronAPI.Models.Order;
using PositronAPI.Services.DepartmentService;
using PositronAPI.Services.EmployeeService;
using System.ComponentModel.DataAnnotations;

namespace PositronAPI.Controllers
{
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        private readonly IDepartmentService _departmentService;

        public EmployeesController(IEmployeeService employeeService, IDepartmentService departmentService)
        {
            _employeeService = employeeService;
            _departmentService = departmentService;
        }

        [HttpPost]
        [Route("/employee")]
        public async Task<ActionResult<Employee>> CreateEmployee([FromBody] EmployeeImportDTO body)
        {
            if (await IsValidEmployee(body))
            {
                var newEmployee = new Employee { Name = body.Name, Surname = body.Surname, Role = body.Role, Wage = body.Wage, DepartmentId = body.DepartmentId };
                
                var response = await _employeeService.CreateEmployee(newEmployee);

                if (response == null) { return BadRequest(); }
                else { return Created(String.Empty, response); }
            }

            return BadRequest("Given object is not valid");
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
        public async Task<ActionResult<List<Employee>>> GetEmployeesByRole([FromRoute][Required] Role roleId, [FromQuery] int top, [FromQuery] int skip)
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

        private async Task<bool> IsValidEmployee(EmployeeImportDTO employee)
        {
            if(employee == null ||
               String.IsNullOrEmpty(employee.Name) ||
               String.IsNullOrEmpty(employee.Surname) ||
               await _departmentService.GetDepartment(employee.DepartmentId) == null ||
               !Enum.IsDefined(typeof(Role), employee.Role) ||
                employee.Wage < 0) { return false; }

            return true;
        }
    }
}
