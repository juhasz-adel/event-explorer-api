using EventExplorer.Api.Models;
using EventExplorer.Api.Persistence.Repositories;
using EventExplorer.Api.Services.Exceptions;
using System.Collections.Generic;

namespace EventExplorer.Api.Services
{
    public class LocationService
    {
        private readonly LocationRepository _locationRepository;

        public LocationService(LocationRepository locationRepository)
        {
            _locationRepository = locationRepository;
        }

        public IEnumerable<Location> GetLocations()
        {
            return _locationRepository.GetLocations();
        }

        public Location GetLocation(int id)
        {
            var location = _locationRepository.GetLocation(id);

            if (location is null)
            {
                throw new LocationNotFoundException(id);
            }

            return location;
        }

        public void Add(Location location)
        {
            _locationRepository.Add(location);
        }
    }
}
