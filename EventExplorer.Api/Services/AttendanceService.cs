using EventExplorer.Api.Models;
using EventExplorer.Api.Persistence.Repositories;

namespace EventExplorer.Api.Services
{
    public class AttendanceService
    {
        private readonly AttendanceRepository _attendanceRepository;

        public AttendanceService(AttendanceRepository attendanceRepository)
        {
            _attendanceRepository = attendanceRepository;
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
