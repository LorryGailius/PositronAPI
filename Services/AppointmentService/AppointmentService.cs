using Microsoft.EntityFrameworkCore;
using PositronAPI.Context;
using PositronAPI.Models.Schedule;

namespace PositronAPI.Services.AppointmentService
{
    public class AppointmentService : IAppointmentService
    {
        private readonly AppDbContext _context;

        public AppointmentService(AppDbContext context)
        {
            _context = context;
        }

        // Add an appointment
        public async Task<Appointment> CreateAppointment(AppointmentImportDTO appointment)
        {
            var newAppointment = new Appointment { CustomerId = appointment.CustomerId, ServiceId = appointment.ServiceId, Date = appointment.Date };

            _context.Appointments.Add(newAppointment);
            await _context.SaveChangesAsync();
            return newAppointment;
        }

        // Remove an appointment
        public async Task<Appointment> DeleteAppointment(long appointmentId)
        {
            var appointment = await _context.Appointments.FindAsync(appointmentId);
            if (appointment == null)
            {
                return null;
            }

            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            return appointment;
        }

        // Edit an appointment
        public async Task<Appointment> EditAppointment(AppointmentUpdateDTO appointment, long appointmentId)
        {
            var existingAppointment = await _context.Appointments.FindAsync(appointmentId);
            if (existingAppointment == null)
            {
                return null;
            }

            existingAppointment.CustomerId = appointment.CustomerId;
            existingAppointment.ServiceId = appointment.ServiceId;
            existingAppointment.Date = appointment.Date;

            await _context.SaveChangesAsync();

            return existingAppointment;
        }

        // Get an appointment
        public async Task<Appointment> GetAppointment(long appointmentId)
        {
            return await _context.Appointments.FindAsync(appointmentId);
        }

        // Get all upcoming appointments for a customer
        public async Task<List<Appointment>> GetAppointments(long customerId)
        {
            return await _context.Appointments.Where(a => a.CustomerId == customerId && a.Date > DateTime.Now).ToListAsync();
        }

        // Get appointments for a service
        public async Task<List<Appointment>> GetAppointmentsForService(long serviceId)
        {
            return await _context.Appointments.Where(a => a.ServiceId == serviceId).ToListAsync();
        }

        // Get overlapping appointments for a service and date within the duration of the service
        public async Task<List<Appointment>> GetOverlappingAppointments(long serviceId, DateTime date)
        {
            var service = await _context.Services.FindAsync(serviceId);
            if (service == null)
            {
                return null;
            }

            var allEmployeeService = await _context.Services.Where(s => s.EmployeeId == service.EmployeeId).ToListAsync();

            var appointments = await _context.Appointments
                .Where(a => allEmployeeService.Select(x => x.Id).Contains(a.ServiceId) && a.Date == date.Date)
                .ToListAsync();

            var overlappingAppointments = new List<Appointment>();

            foreach (var appointment in appointments)
            {
                // Get the service for the appointment
                var appointmentService = allEmployeeService.FirstOrDefault(x => x.Id == appointment.ServiceId);

                if (date <= appointment.Date && date.AddMinutes(service.Duration) >= appointment.Date ||
                    date >= appointment.Date && appointment.Date.AddMinutes(appointmentService.Duration) <= date)
                {
                    overlappingAppointments.Add(appointment);
                }
            }

            return overlappingAppointments;
        }
    }
}
