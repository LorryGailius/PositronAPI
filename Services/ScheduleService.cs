using Microsoft.EntityFrameworkCore;
using PositronAPI.Context;
using PositronAPI.Models.Employee;

namespace PositronAPI.Services
{
    public class ScheduleService
    {
        private readonly AppDbContext _context;

        public ScheduleService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Schedule> CreateSchedule(Schedule schedule)
        {
            Schedule newSchedule = new()
            {
                EmployeeId = schedule.EmployeeId,
                StartDate = schedule.StartDate,
                EndDate = schedule.EndDate,
            };

            _context.Schedules.Add(newSchedule);
            await _context.SaveChangesAsync();
            return newSchedule;
        }

        public async Task<Schedule> DeleteSchedule(long employeeId)
        {
            var schedule = await _context.Schedules.FindAsync(employeeId);
            if (schedule == null)
            {
                return null;
            }

            _context.Schedules.Remove(schedule);
            await _context.SaveChangesAsync();
            return schedule;
        }

        public async Task<Schedule> EditSchedule(Schedule schedule, long employeeId)
        {
            var existingSchedule = await _context.Schedules.FindAsync(employeeId);
            if (existingSchedule == null)
            {
                return null;
            }

            existingSchedule.StartDate = schedule.StartDate;
            existingSchedule.EndDate = schedule.EndDate;

            await _context.SaveChangesAsync();

            return existingSchedule;
        }

        public async Task<Schedule> GetSchedule(long employeeId)
        {
            var schedule = await _context.Schedules.FindAsync(employeeId);
            if (schedule == null)
            {
                return null;
            }
            return schedule;
        }

        public async Task<List<Schedule>> GetSchedules(int top = 10, int skip = 0)
        {
            return await _context.Schedules.Skip(skip).Take(top).ToListAsync();
        }

    }
}
