using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using PositronAPI.Models.Schedule;
using PositronAPI.Services.AppointmentService;
using PositronAPI.Services.CustomerService;
using PositronAPI.Services.ServicesService;

namespace PositronAPI.Controllers
{
    public class AppointmentsController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IServicesService _servicesService;
        private readonly ICustomerService _customerService;

        public AppointmentsController(IAppointmentService appointmentService, IServicesService servicesService, ICustomerService customerService)
        {
            _appointmentService = appointmentService;
            _servicesService = servicesService;
            _customerService = customerService;
        }

        [HttpPost]
        [Route("/appointment")]
        public async Task<ActionResult<Appointment>> CreateAppointment([FromBody][Required] AppointmentImportDTO body)
        {
            if (await IsValidAppointment(body))
            {
                var response = await _appointmentService.CreateAppointment(body);

                if (response == null) { return BadRequest(); }
                else { return Created(String.Empty, response); }
            }

            return BadRequest("Given object is not valid");
        }

        [HttpDelete]
        [Route("/appointment/{appointmentId}")]
        public async Task<ActionResult> DeleteAppointment([FromRoute] long appointmentId)
        {
            var response = await _appointmentService.DeleteAppointment(appointmentId);

            if (response == null) { return NotFound(); }
            return NoContent();
        }

        [HttpPut]
        [Route("/appointment/{appointmentId}")]
        public async Task<ActionResult<Appointment>> EditAppointment([FromBody][Required] AppointmentUpdateDTO body, [FromRoute][Required] long appointmentId)
        {
            if (body == null) { return BadRequest(); }
            var response = await _appointmentService.EditAppointment(body, appointmentId);

            if (response == null) { return BadRequest(); }
            else { return Ok(response); }
        }

        [HttpGet]
        [Route("/appointment/{appointmentId}")]
        public async Task<ActionResult<Appointment>> GetAppointment([FromRoute] long appointmentId)
        {
            var response = await _appointmentService.GetAppointment(appointmentId);

            if (response == null) { return NotFound(); }
            else { return Ok(response); }
        }

        public async Task<bool> IsValidAppointment(AppointmentImportDTO appointment)
        {
            if (appointment.CustomerId == 0 ||
                appointment.ServiceId == 0 ||
                appointment.Date == DateTime.MinValue) { return false; }

            var overlap = await _appointmentService.GetOverlappingAppointments(appointment.ServiceId, appointment.Date);

            if (overlap.Count > 0) { return false; }

            return true;
        }
    }
}
