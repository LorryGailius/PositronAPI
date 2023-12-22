using Microsoft.AspNetCore.Mvc;
using PositronAPI.Models.Schedule;
using PositronAPI.Services.AppointmentService;
using PositronAPI.Services.CustomerService;
using PositronAPI.Services.ServicesService;

namespace PositronAPI.Controllers
{
    public class AppointmentsController : ControllerBase
    {
        private readonly AppointmentService _appointmentService;
        private readonly ServicesService _servicesService;
        private readonly CustomerService _customerService;

        public AppointmentsController(AppointmentService appointmentService, ServicesService servicesService, CustomerService customerService)
        {
            _appointmentService = appointmentService;
            _servicesService = servicesService;
            _customerService = customerService;
        }

        [HttpPost]
        [Route("/appointment")]
        public async Task<ActionResult<Appointment>> CreateAppointment([FromBody] Appointment body)
        {
            if (await IsValidAppointment(body))
            {                
                var newAppointment = new Appointment { CustomerId = body.CustomerId, ServiceId = body.ServiceId, Date = body.Date };
                
                var respone = await _appointmentService.CreateAppointment(newAppointment);

                if (respone == null) { return BadRequest(); }
                else { return Ok(respone); }
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

        public async Task<bool> IsValidAppointment(Appointment appointment)
        {
            if (appointment == null ||
                appointment.CustomerId == 0 ||
                await _customerService.GetCustomer(appointment.CustomerId) == null ||
                appointment.ServiceId == 0 ||
                await _servicesService.GetService(appointment.ServiceId) == null ||
                appointment.Date == DateTime.MinValue) { return false; }

            var overlap = await _appointmentService.GetOverlappingAppointments(appointment.ServiceId, appointment.Date);

            if (overlap.Count > 0) { return false; }

            return true;
        }
    }
}
