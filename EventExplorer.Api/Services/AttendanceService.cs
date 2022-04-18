using System;
using EventExplorer.Api.Models;
using EventExplorer.Api.Persistence.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace EventExplorer.Api.Services
{
    public class AttendanceService
    {
        private readonly AttendanceRepository _attendanceRepository;

        public AttendanceService(AttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
        }

        public IEnumerable<Event> GetUpcomingUserEvents(int userId)
        {
            var attendances = _attendanceRepository.GetAttendances(userId);

            return attendances
                .Select(attendance => attendance.Event)
                .Where(@event => @event.StartDate.Month == DateTime.Now.Month)
                .ToList();
        }

        public IEnumerable<Event> GetFurtherUserEvents(int userId)
        {
            var attendances = _attendanceRepository.GetAttendances(userId);

            return attendances
                .Select(attendance => attendance.Event)
                .Where(@event => @event.StartDate.Month != DateTime.Now.Month)
                .ToList();
        }

        public Attendance GetAttendance(int eventId, int userId)
        {
            return _attendanceRepository.GetAttendance(eventId, userId);
        }

        public void Add(Attendance attendance)
        {
            _attendanceRepository.Add(attendance);
        }
    }
}
