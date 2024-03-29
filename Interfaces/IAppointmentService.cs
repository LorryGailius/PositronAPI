using PositronAPI.Models.Schedule;

namespace PositronAPI.Services.AppointmentService
{
    public interface IAppointmentService
    {
        Task<Appointment> CreateAppointment(AppointmentImportDTO appointment);
        Task<Appointment> DeleteAppointment(long appointmentId);
        Task<Appointment> EditAppointment(AppointmentUpdateDTO appointment, long appointmentId);
        Task<Appointment> GetAppointment(long appointmentId);
        Task<List<Appointment>> GetAppointments(long customerId);
        Task<List<Appointment>> GetAppointmentsForService(long serviceId);
        Task<List<Appointment>> GetOverlappingAppointments(long serviceId, DateTime date);
    }
}
