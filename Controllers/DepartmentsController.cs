using Microsoft.AspNetCore.Mvc;
using PositronAPI.Models.Department;
using PositronAPI.Services.DepartmentService;
using PositronAPI.Services.EmployeeService;
using System.ComponentModel.DataAnnotations;

namespace PositronAPI.Controllers
{
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;
        private readonly IEmployeeService _employeeService;

        public DepartmentsController(IDepartmentService departmentService, IEmployeeService employeeService)
        {
            _departmentService = departmentService;
            _employeeService = employeeService;
        }

        [HttpPost]
        [Route("/department")]
        public async Task<ActionResult<Department>> CreateDepartment([FromBody] DepartmentImportDTO body)
        {
            if (IsValidDepartment(body))
            {
                var newDepartment = new Department { ManagerId = body.ManagerId, Name = body.Name};

                var response = await _departmentService.CreateDepartment(newDepartment);

                if (response == null) { return BadRequest(); }
                else { return Created(String.Empty, response); }
            }

            return BadRequest("Given object is not valid");
        }

        [HttpDelete]
        [Route("/department/{departmentId}")]
        public async Task<ActionResult> DeleteDepartment([FromRoute][Required] long departmentId)
        {
            var response = await _departmentService.DeleteDepartment(departmentId);

            if (response == null) { return NotFound(); }
            return NoContent();
        }

        [HttpPut]
        [Route("/department/{departmentId}")]
        public async Task<ActionResult<Department>> EditDepartment([FromBody][Required] DepartmentUpdateDTO body, [FromRoute][Required] long departmentId)
        {
            var response = await _departmentService.EditDepartment(body, departmentId);

            if (response == null) { return BadRequest(); }
            else { return Ok(response); }
        }

        [HttpGet]
        [Route("/department/{departmentId}")]
        public async Task<ActionResult<Department>> GetDepartment([FromRoute][Required] long departmentId)
        {
            var response = await _departmentService.GetDepartment(departmentId);

            if (response == null) { return NotFound(); }
            else { return Ok(response); }
        }

        [HttpGet]
        [Route("/department")]
        public async Task<ActionResult<List<Department>>> GetDepartments([FromQuery] int top, [FromQuery] int skip)
        {
            if (top < 0 || skip < 0) { return BadRequest(); }

            var response = (top > 0 || skip > 0) ? await _departmentService.GetDepartments(top, skip) : await _departmentService.GetDepartments();

            if (response == null) { return NotFound(); }
            else { return Ok(response); }
        }

        public bool IsValidDepartment(DepartmentImportDTO department)
        {
            if (department == null ||
               String.IsNullOrEmpty(department.Name)) { return false; }

            return true;
        }
    }
}
