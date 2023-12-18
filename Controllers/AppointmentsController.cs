using Microsoft.AspNetCore.Mvc;
using PositronAPI.Models.Schedule;
using PositronAPI.Services.AppointmentService;

namespace PositronAPI.Controllers
{
    public class AppointmentsController : ControllerBase
    {
        private readonly AppointmentService _appointmentService;

        public AppointmentsController(AppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost]
        [Route("/appointment")]
        public async Task<ActionResult<Appointment>> CreateAppointment([FromBody] Appointment body)
        {
            if( await IsValidAppointment(body))
            {
                var respone = await _appointmentService.CreateAppointment(body);
                if(respone == null) { return BadRequest(); }
                else { return Ok(respone); }
            }
            else { return BadRequest(); }
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
        public async Task<ActionResult<Appointment>> EditAppointment([FromBody] Appointment body, [FromRoute] long appointmentId)
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

        public async Task<Boolean> IsValidAppointment(Appointment appointment)
        {
            if (appointment == null) { return false; }

            var overlap = await _appointmentService.GetOverlappingAppointments(appointment.ServiceId, appointment.Date);

            if (overlap.Count > 0) { return false; }

            return true;
        }
    }
}
