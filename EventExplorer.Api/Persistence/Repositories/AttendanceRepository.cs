using EventExplorer.Api.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace EventExplorer.Api.Persistence.Repositories
{
    public class AttendanceRepository
    {
        private readonly ApplicationDbContext _context;

        public AttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Attendance> GetAttendances(int userId)
        {
            return _context.Attendances
                .Include(attendance => attendance.Event.Organizer)
                .Include(attendance => attendance.Event.Category)
                .Include(attendance => attendance.Event.Location)
                .Where(attendance => attendance.UserId == userId)
                .ToList();
        }

        public Attendance GetAttendance(int eventId, int userId)
        {
            return _context.Attendances
                .Include(attendance => attendance.User)
                .Include(attendance => attendance.Event.Organizer)
                .Include(attendance => attendance.Event.Category)
                .Include(attendance => attendance.Event.Location)
                .SingleOrDefault(attendance => attendance.EventId == eventId &&
                    attendance.UserId == userId);
        }

        public void Add(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
            _context.SaveChanges();
        }
    }
}
