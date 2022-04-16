using EventExplorer.Api.Models;

namespace EventExplorer.Api.Persistence.Repositories
{
    public class AttendanceRepository
    {
        private readonly ApplicationDbContext _context;

        public AttendanceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Attendance attendance)
        {
            _context.Attendances.Add(attendance);
            _context.SaveChanges();
        }
    }
}
