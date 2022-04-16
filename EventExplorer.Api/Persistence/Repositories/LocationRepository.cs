using EventExplorer.Api.Models;
using System.Collections.Generic;
using System.Linq;

namespace EventExplorer.Api.Persistence.Repositories
{
    public class LocationRepository
    {
        private readonly ApplicationDbContext _context;

        public LocationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Location> GetLocations()
        {
            return _context.Locations.ToList();
        }

        public Location GetLocation(int id)
        {
            return _context.Locations
                .SingleOrDefault(location => location.Id == id);
        }

        public void Add(Location location)
        {
            _context.Locations.Add(location);
            _context.SaveChanges();
        }
    }
}
