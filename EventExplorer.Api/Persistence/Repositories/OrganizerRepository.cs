using EventExplorer.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace EventExplorer.Api.Persistence.Repositories
{
    public class OrganizerRepository
    {
        private readonly ApplicationDbContext _context;

        public OrganizerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Organizer> GetOrganizers()
        {
            return _context.Organizers.ToList();
        }

        public Organizer GetOrganizer(int id)
        {
            return _context.Organizers
                .SingleOrDefault(organizer => organizer.Id == id);
        }

        public void Add(Organizer organizer)
        {
            _context.Organizers.Add(organizer);
            _context.SaveChanges();
        }
    }
}
