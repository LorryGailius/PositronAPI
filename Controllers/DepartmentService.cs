using Microsoft.AspNetCore.Mvc;
using PositronAPI.Models.Department;
using PositronAPI.Services.CustomerService;
using System.ComponentModel.DataAnnotations;

namespace PositronAPI.Controllers
{
    public class DepartmentService : ControllerBase
    {
        private readonly DepartmentService _departmentService;

        public DepartmentService(DepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpPost]
        [Route("/department")]
        public async Task<ActionResult<Department>> CreateDepartment([FromBody] Department body)
        {
            if (body == null) { return BadRequest(); }
            var response = await _departmentService.CreateDepartment(body);

            if (response == null) { return BadRequest(); }
            else { return Ok(response); }
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
        public async Task<ActionResult<Department>> EditDepartment([FromBody] Department body, [FromRoute][Required] long departmentId)
        {
            if (body == null) { return BadRequest(); }
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
            
    }
}
